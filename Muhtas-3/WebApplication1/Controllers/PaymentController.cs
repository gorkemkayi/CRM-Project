using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        Context context = new Context();
        public ActionResult Index()
        {
            var payment = context.Payments.Where(x =>x.Invoice.DeleteInvoice == false).ToList();

            return View(payment);
        }

        [HttpGet]
        public ActionResult AddPayment(int id)
        {
            var invoice = context.Invoices.FirstOrDefault(x => x.ID == id);
            List<SelectListItem> paymentMode = new List<SelectListItem>
        {
            new SelectListItem
            {
                Text = invoice.PaymentMethod,
                Value = invoice.PaymentMethod
            }
        };

            ViewBag.paymentMode = paymentMode;

            var invoiceID = context.Invoices.Where(x => x.ID == id).Select(x => x.ID).FirstOrDefault();
            ViewBag.InvoiceID = invoiceID;




            return View();
        }
        [HttpPost]
        public ActionResult AddPayment(Payment payment, int id)
        {

            context.Payments.Add(payment);


            var invoice = context.Invoices.FirstOrDefault(x => x.ID == id);

            if (invoice != null && invoice.Payments.Any())
            {
                decimal? totalAmountReceived = invoice.Payments.Sum(s => s.AmountReceived);

                if (totalAmountReceived == invoice.Amount)
                {
                    invoice.Status = "Paid";
                }
                else if (totalAmountReceived != null && totalAmountReceived != invoice.Amount)
                {
                    invoice.Status = "Partially Paid";
                }
            }

            context.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult PaymentPDF()
        {
            var payments=context.Payments.ToList();
            return View(payments);
        }
       
    }
}