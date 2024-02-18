using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ItemGroupController : Controller
    {
        // GET: ItemGroup
        Context context=new Context();
        public ActionResult Index()
        {
            var itemGroups=context.ItemGroups.ToList();
            return View(itemGroups);
        }

        [HttpGet]
        public ActionResult AddNewItemGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewItemGroup(ItemGroup itemGroup)
        {
            context.ItemGroups.Add(itemGroup);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}