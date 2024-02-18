using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var customer = context.Customers.Where(x=>x.Status==true).ToList();
            ///// Tüm Customerlar
            int customerCount=context.Customers.Count();
            ViewBag.CustomerCount = customerCount;
            /////
            
            /// Aktif Customerlar
            int activeCustomerCount=context.Customers.Where(x=>x.Status==true).Count();
            ViewBag.ActiveCustomerCount = activeCustomerCount;
            /// 

            ///İnaktif Kullanıcılar
            int inactiveCustomerCount = context.Customers.Where(x => x.Status == false).Count();
            ViewBag.InactiveCustomerCount = inactiveCustomerCount;
            ///

            ////Aktif Contactlar
            int contactCount=context.Contacts.Where(x=>x.Status==true).Count();
            ViewBag.activeContactCount = contactCount;
            ///////
            
            ////Aktif Contactlar
            int inactiveContactCount=context.Contacts.Where(x=>x.Status == false).Count();
            ViewBag.InactiveContactCount= inactiveContactCount;
            ///




            return View(customer);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            List<SelectListItem> Language = (from x in context.Languages.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.LanguageName,
                                                 Value = x.ID.ToString()
                                             }).ToList();

            ViewBag.language = Language;  //viewbag controllerdan view a veri taşımaya yarar

            List<SelectListItem> Country = (from x in context.Countries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CountryName,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.country = Country;


            List<SelectListItem> Group = (from x in context.Groups.Where(x=>x.isDeleted==false).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.GroupName,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.group = Group;


            List<SelectListItem> Currency = (from x in context.Currencies.Where(x=>x.isDeleted==false).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrencyName,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.currency = Currency;

            


            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {            
            customer.Status = true;
            context.Customers.Add(customer);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            List<SelectListItem> Group = (from x in context.Groups.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.GroupName,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.group = Group;

            List<SelectListItem> Currency = (from x in context.Currencies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrencyName,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.currency = Currency;

            List<SelectListItem> Language=(from x in context.Languages.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.LanguageName,
                                               Value=x.ID.ToString()    
                                           }).ToList() ;
            ViewBag.language = Language;

            List<SelectListItem> Country = (from x in context.Countries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CountryName,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.country = Country;
                                        

            var editcustomer = context.Customers.Where(x => x.ID == id).FirstOrDefault();
            return View(editcustomer);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            var editcustomer=context.Customers.Where(x=>x.ID == customer.ID).FirstOrDefault();
            editcustomer.Company = customer.Company;
            editcustomer.VatNumber=customer.VatNumber;
            editcustomer.Phone=customer.Phone;
            editcustomer.Website=customer.Website;
            editcustomer.Address=customer.Address;
            editcustomer.City=customer.City;
            editcustomer.State=customer.State;
            editcustomer.ZipCode=customer.ZipCode;
            editcustomer.LanguageId=customer.LanguageId;
            editcustomer.CountryId=customer.CountryId;
            editcustomer.GroupId=customer.GroupId;
            editcustomer.CurrencyId=customer.CurrencyId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var deletecustomer=context.Customers.Where(x=>x.ID==id).FirstOrDefault();
            deletecustomer.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerPDF()
        {
            var customers = context.Customers.Where(x=>x.Status==true).ToList();
            return View(customers);
        }

    }
}