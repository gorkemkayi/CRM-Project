using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ContractController : Controller
    {
        // GET: Contract
        Context context = new Context();
        public ActionResult Index()
        {
            var contract = context.Contracts.Where(x=>x.isDeleted==false).ToList();



            return View(contract);
        }
        


        [HttpGet]
        public ActionResult AddContract()
        {
            List<SelectListItem> customer = (from x in context.Customers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Company,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Customer = customer;

            List<SelectListItem> contractTypes = (from x in context.ContractTypes.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.ID.ToString(),
                                                  }).ToList();
            ViewBag.ContractTypes = contractTypes;
            return View();
        }

        [HttpPost]
        public ActionResult AddContract(Contract contract)
        {
            context.Contracts.Add(contract);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditContract(int id)
        {
            List<SelectListItem> customer = (from x in context.Customers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Company,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Customer = customer;

            List<SelectListItem> contractTypes = (from x in context.ContractTypes.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.ID.ToString(),
                                                  }).ToList();
            ViewBag.ContractTypes = contractTypes;

            var editContract = context.Contracts.Where(x => x.ID == id).FirstOrDefault();
            return View(editContract);
        }

        [HttpPost]
        public ActionResult EditContract(Contract contract)
        {
            var editContract = context.Contracts.Where(x => x.ID == contract.ID).FirstOrDefault();

            editContract.CustomerID = contract.CustomerID;
            editContract.Subject = contract.Subject;
            editContract.ContractValue = contract.ContractValue;
            editContract.StartDate = contract.StartDate;
            editContract.EndDate = contract.EndDate;
            editContract.Description = contract.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContract(int id)
        {
            var deleteContract = context.Contracts.Where(x => x.ID == id).FirstOrDefault();
            deleteContract.isDeleted= true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult ContractPDF()
        {
            var contracts=context.Contracts.Where(x=>x.isDeleted==false).ToList();
            return View(contracts);
        }
    }
}