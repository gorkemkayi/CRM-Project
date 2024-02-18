using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        // GET: ExpenseCategory
        Context context =new Context();
        public ActionResult Index()
        {
           var expenseCategory=context.ExpenseCategories.Where(x=>x.isDeleted==false).ToList();
            return View(expenseCategory);
        }
        [HttpGet]
        public ActionResult NewExpenseCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewExpenseCategory(ExpenseCategory expenseCategory)
        {
            context.ExpenseCategories.Add(expenseCategory);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var expenseCategory = context.ExpenseCategories.Where(x => x.ID == id).FirstOrDefault();
            return View(expenseCategory);
        }
        [HttpPost]
        public ActionResult EditCategory(ExpenseCategory expenseCategory)
        {
            var expenseCat=context.ExpenseCategories.Where(x=>x.ID==expenseCategory.ID).FirstOrDefault();
            expenseCat.Name = expenseCategory.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var deleteCategory=context.ExpenseCategories.Where(x=>x.ID == id).FirstOrDefault();
            deleteCategory.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ExpenseCategoryPDF()
        {
            var expenseCategories=context.ExpenseCategories.Where(x=>x.isDeleted==false).ToList();
            return View(expenseCategories);
        }
    }
}