using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class CustomerGroupController : Controller
    {
        // GET: CustomerGroup
        Context context = new Context();
        public ActionResult Index()
        {
            var groups = context.Groups.Where(x => x.isDeleted == false).ToList();
            return View(groups);
        }

        [HttpGet]
        public ActionResult NewGroup()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewGroup(Group group)
        {
            context.Groups.Add(group);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditGroup(int id)
        {
            var editGoup = context.Groups.Where(x => x.ID == id).FirstOrDefault();
            return View(editGoup);
        }
        [HttpPost]
        public ActionResult EditGroup(Group group)
        {
            var editGroup = context.Groups.Where(x => x.ID == group.ID).FirstOrDefault();
            editGroup.GroupName = group.GroupName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteGroup(int id)
        {
            var deleteGroup=context.Groups.Where(x=>x.ID == id).FirstOrDefault();
            deleteGroup.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerGroupPDF()
        {
            var custGroups=context.Groups.Where(x=>x.isDeleted==false).ToList();
            return View(custGroups);
        }
    }
}