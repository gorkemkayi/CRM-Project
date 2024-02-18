using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class SupportStatusController : Controller
    {
        // GET: SupportStatus
        Context context=new Context();
        public ActionResult Index()
        {
            var status = context.SupportStatuses.Where(x=>x.isDeleted==false).ToList();
            return View(status);
        }

        [HttpGet]
        public ActionResult NewStatus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewStatus(SupportStatus supportStatus)
        {
            context.SupportStatuses.Add(supportStatus);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditStatus(int id)
        {
            var editStatus=context.SupportStatuses.Where(x=>x.ID==id).FirstOrDefault();
            return View(editStatus);
        }

        public ActionResult EditStatus(SupportStatus supportStatus)
        {
            var editStatus=context.SupportStatuses.Where(x=>x.ID==supportStatus.ID).FirstOrDefault();
            editStatus.Name = supportStatus.Name;
            return RedirectToAction("Index");
        }

        public ActionResult StatuePDF()
        {
            var statues = context.SupportStatuses.Where(x => x.isDeleted == false).ToList();
            return View(statues);
        }
    }
}