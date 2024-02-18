using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class TaxController : Controller
    {
        // GET: Tax
        Context context=new Context();
        public ActionResult Index()
        {
            var taxes=context.Taxes.Where(x=>x.isDeleted==false).ToList();
            return View(taxes);
        }

        [HttpGet]
        public ActionResult EditTax(int id)
        {
            var editTax = context.Taxes.Where(x => x.TaxID == id).FirstOrDefault();
            return View(editTax);
        }

        [HttpPost]
        public ActionResult EditTax(Tax tax)
        {
            var editTax = context.Taxes.Where(x => x.TaxID == tax.TaxID).FirstOrDefault();
            editTax.TaxID = tax.TaxID;
            editTax.TaxValue = tax.TaxValue;
            editTax.TaxName = tax.TaxName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NewTax()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewTax(Tax tax)
        {
            context.Taxes.Add(tax);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTax(int id)
        {
            var deleteTax=context.Taxes.Where(x=>x.TaxID == id).FirstOrDefault();
            deleteTax.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TaxPDF()
        {
            var taxes=context.Taxes.Where(x=>x.isDeleted==false).ToList();
            return View(taxes);
        }
    }
}