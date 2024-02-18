using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context context=new Context();
        public ActionResult Index()
        {
            var departments = context.Departments.Where(x=>x.isDeleted==false).ToList();
            return View(departments);
        }

        [HttpGet]
        public ActionResult NewDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewDepartment(Department department)
        {
            var newDepartment=context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditDepartment(int id)
        {
            var editDepartment = context.Departments.Where(x => x.ID == id).FirstOrDefault();
            return View(editDepartment);
        }

        [HttpPost]
        public ActionResult EditDepartment(Department department)
        {
            var editDepartment=context.Departments.Where(x=>x.ID == department.ID).FirstOrDefault();
            editDepartment.Email = department.Email;
            editDepartment.Name = department.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var deleteDepartment=context.Departments.Where(x=>x.ID==id).FirstOrDefault();
            deleteDepartment.isDeleted=true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentPDF()
        {
            var dpartments=context.Departments.Where(x=>x.isDeleted==false).ToList();
            return View(dpartments);
        }
    }
}