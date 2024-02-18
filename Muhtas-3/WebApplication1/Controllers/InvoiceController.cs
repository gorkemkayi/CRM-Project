using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context context = new Context();
        public ActionResult Index()
        {
            var invoices = context.Invoices.Where(x=>x.DeleteInvoice==false).ToList();
            foreach (var item in invoices)
            {
                var subtotal = item.Qty * item.Item.Rate;
                var taxAmount = subtotal * item.Item.Tax.TaxValue;

                item.Amount = subtotal + taxAmount;

            }
            
            

            return View(invoices);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            List<SelectListItem> customer=(from x in context.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.Company,
                                               Value=x.ID.ToString(),
                                           }).ToList();
            ViewBag.Customer = customer;

            List<SelectListItem> country=(from x in context.Countries.ToList()
                                          select new SelectListItem
                                          {
                                              Text=x.CountryName,
                                              Value=x.ID.ToString(),
                                          }).ToList() ;
            ViewBag.Country = country;

            List<SelectListItem> tag = (from x in context.Tags.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.TagID.ToString()
                                        }).ToList();
            ViewBag.Tag = tag;

            List<SelectListItem> paymentMethod=new List<SelectListItem>
            {
                new SelectListItem{Text="Bank",Value="Bank"},
                new SelectListItem{Text="Stripe Checkout",Value="StripeCheckout"}
            }.ToList();
            ViewBag.PaymentMethod = paymentMethod;

            List<SelectListItem> currency = (from x in context.Currencies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrencyName,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Currency = currency;

            List<SelectListItem> saleAgent=(from x in context.SaleAgents.ToList()
                                            select new SelectListItem
                                            {
                                                Text=x.Name,
                                                Value=x.SaleAgentID.ToString()
                                            }).ToList();
            ViewBag.SaleAgent = saleAgent;

            List<SelectListItem> recurringInvoice = new List<SelectListItem>
            {
                new SelectListItem{Text="Yes",Value="Yes"},
                new SelectListItem{Text="No",Value="No"}
            }.ToList();
            ViewBag.RecurringInvoice = recurringInvoice;

            List<SelectListItem> discountType = new List<SelectListItem>
            {
                new SelectListItem{Text="No Discount",Value="NoDiscount"},
                new SelectListItem{Text="Before Tax",Value="BeforeTax"},
                new SelectListItem{Text="After Tax",Value="AfterTax"}
            }.ToList();
            ViewBag.DiscountType = discountType;

            List<SelectListItem> item = (from x in context.Items.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.ItemID.ToString()
                                         }).ToList();
            ViewBag.item = item;

            return View();
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInvoice(int id)
        {
            var deleteInvoice=context.Invoices.Where(x=>x.ID==id).FirstOrDefault();
            deleteInvoice.DeleteInvoice=true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetail(int id)
        {
            List<Invoice> invoices = context.Invoices.Where(x=>x.ID==id).ToList();
            foreach (var item in invoices)
            {
                var subtotal = item.Qty * item.Item.Rate;
                var taxAmount = subtotal * item.Item.Tax.TaxValue;

                item.Amount = subtotal + taxAmount;
                item.TotalTax = taxAmount;
            }
            context.SaveChanges();
            return View(invoices);
        }

        public ActionResult InvoicePDF()
        {
            var invoices=context.Invoices.Where(x=>x.DeleteInvoice==false).ToList();
            return  View(invoices);
        }


    }
}