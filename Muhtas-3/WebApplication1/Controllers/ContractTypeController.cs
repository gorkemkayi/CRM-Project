using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ContractTypeController : Controller
    {
        // GET: ContractType
        Context context=new Context();
        public ActionResult Index()
        {
            var types=context.ContractTypes.Where(x=>x.isDeleted==false).ToList();
            return View(types);
        }
        [HttpGet]
        public ActionResult NewType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewType(ContractType type)
        {
            context.ContractTypes.Add(type);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditType(int id)
        {
            var editType=context.ContractTypes.Where(x=>x.ID==id).FirstOrDefault();
            return View(editType);
        }
        [HttpPost]
        public ActionResult EditType(ContractType type)
        {
            var editType=context.ContractTypes.Where(x=>x.ID==type.ID).FirstOrDefault();
            editType.Name = type.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteType(int id)
        {
            var deleteType=context.ContractTypes.Where(x=>x.ID==id).FirstOrDefault();
            deleteType.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ContractTypePDF()
        {
            var contractTypes=context.ContractTypes.Where(x=>x.isDeleted==false).ToList();
            return View(contractTypes);
        }
    }
}