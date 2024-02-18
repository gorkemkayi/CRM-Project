using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        Context context=new Context();
        public ActionResult Index()
        {
            var staff=context.Admins.Where(x=>x.isDeleted==false).ToList();
            return View(staff);
        }

        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStaff(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStaff(int id)
        {
            var deleteStaff=context.Admins.Where(x=>x.AdminID==id).FirstOrDefault();
            deleteStaff.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StaffPDF()
        {
            var staff = context.Admins.Where(x => x.isDeleted == false).ToList();
            return View(staff);
        }
    }
}