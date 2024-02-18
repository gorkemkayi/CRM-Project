using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        Context context=new Context();
        public ActionResult Index()
        {
            var service=context.Services.Where(x=>x.isDeleted==false).ToList();
            return View(service);
        }
        [HttpGet]
        public ActionResult NewService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditService(int id)
        {
            var editService=context.Services.Where(x=>x.ID==id).FirstOrDefault();
            return View(editService);
        }
        [HttpPost]
        public ActionResult EditService(Service service)
        {
            var editService=context.Services.Where(x=>x.ID==service.ID).FirstOrDefault();
            editService.Name = service.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var deleteService=context.Services.Where(x=>x.ID==id).FirstOrDefault();
            deleteService.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult ServicePDF()
        {
            var services=context.Services.Where(x=>x.isDeleted==false).ToList();
            return View(services);
        }
    }
}