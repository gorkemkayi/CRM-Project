using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        Context context = new Context();
        public ActionResult Index()
        {
            var items = context.Items.ToList();
            return View(items);
        }
        [HttpGet]
        public ActionResult AddItem()
        {
            List<SelectListItem> tax = (from x in context.Taxes
                                        select new SelectListItem
                                        {
                                            Text = x.TaxValue.ToString(),
                                            Value = x.TaxID.ToString()
                                        }).ToList();
            ViewBag.Taxes = tax;

            List<SelectListItem> Itemgroup = (from x in context.ItemGroups
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.Itemgroup = Itemgroup;

            return View();
        }
        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
            return Redirect("/Proposal/AddProposal");
        }

        [HttpGet]
        public ActionResult AddItemOnIndex()
        {
            List<SelectListItem> tax = (from x in context.Taxes
                                        select new SelectListItem
                                        {
                                            Text = x.TaxValue.ToString(),
                                            Value = x.TaxID.ToString()
                                        }).ToList();
            ViewBag.Taxes = tax;

            List<SelectListItem> Itemgroup =(from x in context.ItemGroups
                                             select new SelectListItem
                                             {
                                                 Text=x.Name,
                                                 Value=x.ID.ToString()
                                             }).ToList() ;
            ViewBag.Itemgroup = Itemgroup;
            return View();
        }
        [HttpPost]
        public ActionResult AddItemOnIndex(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ItemPDF()
        {
            var items = context.Items.ToList();
            return View(items);
        }
    }
}