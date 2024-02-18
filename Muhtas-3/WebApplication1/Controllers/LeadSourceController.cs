using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class LeadSourceController : Controller
    {
        // GET: LeadSource
        Context context = new Context();
        public ActionResult Index()
        {
            var leadSource=context.LeadSources.Where(x=>x.isDeleted==false).ToList();
            return View(leadSource);
        }
        [HttpGet]
        public ActionResult NewSource()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSource(LeadSource leadSource)
        {
            context.LeadSources.Add(leadSource);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSource(int id)
        {
            var editSource=context.LeadSources.Where(x=>x.ID==id).FirstOrDefault();
            return View(editSource);
        }
        [HttpPost]
        public ActionResult EditSource(LeadSource leadSource)
        {
            var editSource=context.LeadSources.Where(x=>x.ID==leadSource.ID).FirstOrDefault();
            editSource.Name = leadSource.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSource(int id)
        {
            var deleteSource=context.LeadSources.Where(x=>x.ID==id).FirstOrDefault();
            deleteSource.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LeadSourcePDF()
        {
            var source = context.LeadSources.Where(x => x.isDeleted == false).ToList();
            return View(source);
        }
    }
}