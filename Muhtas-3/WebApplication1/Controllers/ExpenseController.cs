using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        Context context=new Context();
        public ActionResult Index()
        {
            var expense=context.Expenses.Where(x=>x.isDeleted==false).ToList();
            return View(expense);
        }

        [HttpGet]
        public ActionResult AddExpense()
        {
            List<SelectListItem> expenseCategory=(from x in context.ExpenseCategories.ToList()
                                 select new SelectListItem
                                 {
                                     Text=x.Name,
                                     Value=x.ID.ToString(),
                                 } ).ToList();
            ViewBag.ExpenseCategory = expenseCategory;

            List<SelectListItem> customer=(from x in context.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.Company,
                                               Value=x.ID.ToString(),
                                           }).ToList();
            ViewBag.Customer = customer;

            List<SelectListItem> currency = (from x in context.Currencies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrencyName,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Currency = currency;

            List<SelectListItem> tax = (from x in context.Taxes.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.TaxValue.ToString(),
                                            Value = x.TaxID.ToString(),
                                        }).ToList();
            ViewBag.Tax = tax;

            List<SelectListItem> paymentMode=new List<SelectListItem>
            {
                new SelectListItem{Text="Bank",Value="Bank"},
                new SelectListItem{Text="Stripe Checkout",Value="Stripe Checkout"}
            }.ToList();
            ViewBag.PaymentMode = paymentMode;
            return View();
        }

        [HttpPost]
        public ActionResult AddExpense(Expense expense)
        {
            context.Expenses.Add(expense);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditExpense(int id)
        {
            List<SelectListItem> expenseCategory = (from x in context.ExpenseCategories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString(),
                                                    }).ToList();
            ViewBag.ExpenseCategory = expenseCategory;

            List<SelectListItem> customer = (from x in context.Customers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Company,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Customer = customer;

            List<SelectListItem> currency = (from x in context.Currencies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrencyName,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Currency = currency;

            List<SelectListItem> tax = (from x in context.Taxes.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.TaxValue.ToString(),
                                            Value = x.TaxID.ToString(),
                                        }).ToList();
            ViewBag.Tax = tax;

            List<SelectListItem> paymentMode = new List<SelectListItem>
            {
                new SelectListItem{Text="Bank",Value="Bank"},
                new SelectListItem{Text="Stripe Checkout",Value="Stripe Checkout"}
            }.ToList();
            ViewBag.PaymentMode = paymentMode;

            var editExpense=context.Expenses.Where(x=>x.ID==id).FirstOrDefault();
            return View(editExpense);
        }

        [HttpPost]
        public ActionResult EditExpense(Expense expense)
        {
            var editExpense=context.Expenses.Where(x=>x.ID==expense.ID).FirstOrDefault();
            editExpense.Name= expense.Name;
            editExpense.Note= expense.Note;
            editExpense.ExpenseCategoryID = expense.ExpenseCategoryID;
            editExpense.ExpenseDate = expense.ExpenseDate;
            editExpense.Amount = expense.Amount;
            editExpense.CustomerID = expense.CustomerID;
            editExpense.CurrencyID = expense.CurrencyID;
            editExpense.TaxID = expense.TaxID;
            editExpense.PaymentMode = expense.PaymentMode;
            editExpense.Reference= expense.Reference;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExpense(int id)
        {
            var deleteExpense= context.Expenses.Where(x=>x.ID == id).FirstOrDefault();
            deleteExpense.isDeleted= true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ExpensePDF()
        {
            var expense = context.Expenses.Where(x => x.isDeleted == false).ToList();
            return View(expense);
        }
    }
}