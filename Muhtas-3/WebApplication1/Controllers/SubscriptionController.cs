using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class SubscriptionController : Controller
    {
        // GET: Subscription
        Context context=new Context();
        public ActionResult Index()
        {
            var subscriptions=context.subscriptions.Where(x=>x.isDeleted==false).ToList();

            int subCount= context.subscriptions.Count();
            ViewBag.subcount=subCount;

            int activeSub=context.subscriptions.Where(x=>x.Status==true).Count();
            ViewBag.activeSub=activeSub;

            return View(subscriptions);
        }

        [HttpGet]
        public ActionResult NewSubscription()
        {
           List<SelectListItem> billingPlan=new List<SelectListItem>
           {
               new SelectListItem{Text="Weekly Car Wash Service",Value="WeeklyCarWashService"},
               new SelectListItem{Text="Hosting Monthly",Value="HostingMonthly"}
           }.ToList();
            ViewBag.billingPlan = billingPlan;

            List<SelectListItem> customer=(from x in context.Customers.ToList()
                                           select new SelectListItem{
                Text=x.Company,
                Value=x.ID.ToString(),
            }).ToList();
            ViewBag.customer = customer;

            List<SelectListItem> currency=(from x in context.Currencies.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.CurrencyName, 
                                               Value=x.ID.ToString(),
                                           }).ToList() ;
            ViewBag.currency = currency;

            List<SelectListItem> tax = (from x in context.Taxes.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.TaxValue.ToString(),
                                            Value = x.TaxID.ToString(),
                                        }).ToList();
            ViewBag.tax = tax;

            return View();
        }

        [HttpPost]
        public ActionResult NewSubscription(Subscription subscription)
        {
            context.subscriptions.Add(subscription);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Subscribe(int id)
        {
            var subscribe= context.subscriptions.Where(x=>x.ID==id).FirstOrDefault();
            subscribe.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSub(int id)
        {
            var deleteSub = context.subscriptions.Where(x => x.ID == id).FirstOrDefault();
            deleteSub.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSub(int id)
        {
            var editSub=context.subscriptions.Where(x=>x.ID==id).FirstOrDefault();

            List<SelectListItem> billingPlan = new List<SelectListItem>
           {
               new SelectListItem{Text="Weekly Car Wash Service",Value="WeeklyCarWashService"},
               new SelectListItem{Text="Hosting Monthly",Value="HostingMonthly"}
           }.ToList();
            ViewBag.billingPlan = billingPlan;

            List<SelectListItem> customer = (from x in context.Customers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Company,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.customer = customer;

            List<SelectListItem> currency = (from x in context.Currencies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrencyName,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.currency = currency;

            List<SelectListItem> tax = (from x in context.Taxes.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.TaxValue.ToString(),
                                            Value = x.TaxID.ToString(),
                                        }).ToList();
            ViewBag.tax = tax;

            return View(editSub);
        }

        [HttpPost]
        public ActionResult EditSub(Subscription subscription)
        {
            var editSub=context.subscriptions.Where(x=>x.ID== subscription.ID).FirstOrDefault();
            editSub.BillingPlan= subscription.BillingPlan;
            editSub.Qty= subscription.Qty;
            editSub.FirstBillingDate= subscription.FirstBillingDate;
            editSub.SubName= subscription.SubName;
            editSub.Description= subscription.Description;
            editSub.CustomerID= subscription.CustomerID;
            editSub.CurrencyID= subscription.CurrencyID;
            editSub.TaxID= subscription.TaxID;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SubPDF()
        {
            var subs = context.subscriptions.Where(x=>x.isDeleted==false).ToList();
            return View(subs);
        }
    }
}