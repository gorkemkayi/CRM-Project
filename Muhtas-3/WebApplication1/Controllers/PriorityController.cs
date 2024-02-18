using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class PriorityController : Controller
    {
        // GET: Priority
        Context context = new Context();
        public ActionResult Index()
        {
            var priorities = context.Priorities.Where(x => x.isDeleted == false).ToList();
            return View(priorities);
        }

        [HttpGet]
        public ActionResult NewPriority()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPriority(Priority priority)
        {
            context.Priorities.Add(priority);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPriority(int id)
        {
            var editPriority=context.Priorities.Where(x=>x.ID==id).FirstOrDefault();
            return View(editPriority);
        }
        [HttpPost]
        public ActionResult EditPriority(Priority priority)
        {
            var editPriority=context.Priorities.Where(x=>x.ID==priority.ID).FirstOrDefault();
            editPriority.Name = priority.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletePriority(int id)
        {
            var deletePriority = context.Priorities.Where(x => x.ID == id).FirstOrDefault();
            deletePriority.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PriorityPDF()
        {
            var priority = context.Priorities.Where(x => x.isDeleted == false).ToList();
            return View(priority);
        }
    }
}