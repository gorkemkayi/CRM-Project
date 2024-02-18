using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class LeadStatusController : Controller
    {
        // GET: LeadStatus
        Context context = new Context();
        public ActionResult Index()
        {
            var leadStatus = context.LeadStatuses.Where(x => x.isDeleted == false).ToList();
            return View(leadStatus);
        }
        [HttpGet]
        public ActionResult NewStatus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewStatus(LeadStatus leadStatus)
        {
            var newStatus = context.LeadStatuses.Add(leadStatus);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditStatus(int id)
        {
            var editStatus=context.LeadStatuses.Where(x=>x.ID == id).FirstOrDefault();
            return View(editStatus);
        }
        [HttpPost]
        public ActionResult EditStatus(LeadStatus leadStatus)
        {
            var editStatus=context.LeadStatuses.Where(x=>x.ID==leadStatus.ID).FirstOrDefault();
            editStatus.Name = leadStatus.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStatus(int id)
        {
            var deleteStatus=context.LeadStatuses.Where(x=>x.ID==id).FirstOrDefault();
            deleteStatus.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LeadStatuesPDF()
        {
            var leadStatues=context.LeadStatuses.Where(x=>x.isDeleted==false).ToList();
            return View(leadStatues);
        }
    }
}