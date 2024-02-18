using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class EstimateController : Controller
    {
        // GET: Estimate
        Context context = new Context();
        public ActionResult Index()
        {
            var estimate = context.Estimates.ToList();
            ///////
            foreach (var item in estimate)
            {
                var subtotal = item.Qty * item.Item.Rate;
                var taxAmount = subtotal * item.Item.Tax.TaxValue;

                item.Amount = subtotal + taxAmount;
            }
            /////
            return View(estimate);
        }

        [HttpGet]
        public ActionResult AddEstimate()
        {
            List<SelectListItem> customer = (from x in context.Customers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Company,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.Customer = customer;

            List<SelectListItem> country = (from x in context.Countries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CountryName,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.Country = country;

            List<SelectListItem> tags = (from x in context.Tags.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.TagID.ToString()
                                         }).ToList();
            ViewBag.Tags = tags;
            List<SelectListItem> currency = (from x in context.Currencies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrencyName,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.Currency = currency;

            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem{Text="Draft",Value="Draft"},
               new SelectListItem{Text="Sent",Value="Open"},
               new SelectListItem{Text="Expired",Value="Expired"},
               new SelectListItem{Text="Declined",Value="Declined"},
               new SelectListItem{Text="Accepted",Value="Accepted"},
            }.ToList();
            ViewBag.Status = status;

            List<SelectListItem> saleAgent = (from x in context.SaleAgents.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.SaleAgentID.ToString()
                                              }).ToList();
            ViewBag.SaleAgent = saleAgent;

            List<SelectListItem> discountType = new List<SelectListItem>
            {
                new SelectListItem{Text="No Discount",Value="NoDiscount"},
                new SelectListItem{Text="Before Tax",Value="BeforeTax"},
                new SelectListItem{Text="After Text",Value="AfterText"}
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
        public ActionResult AddEstimate(Estimate estimate)
        {

            context.Estimates.Add(estimate);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EstimatePDF()
        {
            var estimates = context.Estimates.ToList();
            return View(estimates);
        }
    }
}