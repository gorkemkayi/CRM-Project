using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: Currency
        Context context=new Context();
        public ActionResult Index()
        {
            var currency = context.Currencies.Where(x=>x.isDeleted==false).ToList();
            return View(currency);
        }
        [HttpGet]
        public ActionResult NewCurrency()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult NewCurrency(Currency currency)
        {
            context.Currencies.Add(currency);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCurrency(int id)
        {
            var editcurrency=context.Currencies.Where(x=>x.ID==id).FirstOrDefault();
            return View(editcurrency);
        }

        [HttpPost]
        public ActionResult EditCurrency(Currency currency)
        {
            var editcurrency = context.Currencies.Where(x => x.ID == currency.ID).FirstOrDefault();
            editcurrency.CurrencyName = currency.CurrencyName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCurrency(int id)
        {
            var deletecurrency=context.Currencies.Where(x=>x.ID == id).FirstOrDefault();
            deletecurrency.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CurrencyPDF()
        {
            var currencies=context.Currencies.Where(x=>x.isDeleted==false).ToList();
            return View(currencies);
        }
    }
}