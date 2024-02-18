using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class LeadController : Controller
    {
        // GET: Lead
        Context context=new Context();
        public ActionResult Index()
        {
            var lead=context.Leads.Where(x=>x.isDeleted==false).ToList();
            return View(lead);
        }

        [HttpGet]
        public ActionResult NewLead()
        {
            List<SelectListItem> status=(from x in context.LeadStatuses.Where(x=>x.isDeleted==false)
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value=x.ID.ToString(),
                                         }).ToList();
            ViewBag.LeadStatus = status;

            List<SelectListItem> source = (from x in context.LeadSources.Where(x=>x.isDeleted == false)
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.ID.ToString(),
                                           }).ToList();
            ViewBag.LeadSource = source;

            List<SelectListItem> assigned=(from x in context.Assigneds
                                           select new SelectListItem
                                           {
                                               Text= x.Name,
                                               Value=x.ID.ToString(),
                                           }).ToList();
            ViewBag.Assigned= assigned;

            List<SelectListItem> tag = (from x in context.Tags
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.TagID.ToString(),
                                        }).ToList();
            ViewBag.Tag = tag;

            List<SelectListItem> country = (from x in context.Countries
                                            select new SelectListItem
                                            {
                                                Text = x.CountryName,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.Country = country;

            List<SelectListItem> language = (from x in context.Languages
                                             select new SelectListItem
                                             {
                                                 Text = x.LanguageName,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Language = language;
            return View();
        }
        [HttpPost]
        public ActionResult NewLead(Lead lead)
        {
            context.Leads.Add(lead);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditLead(int id)
        {
            List<SelectListItem> status = (from x in context.LeadStatuses
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.ID.ToString(),
                                           }).ToList();
            ViewBag.LeadStatus = status;

            List<SelectListItem> source = (from x in context.LeadSources
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.ID.ToString(),
                                           }).ToList();
            ViewBag.LeadSource = source;

            List<SelectListItem> assigned = (from x in context.Assigneds
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Assigned = assigned;

            List<SelectListItem> tag = (from x in context.Tags
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.TagID.ToString(),
                                        }).ToList();
            ViewBag.Tag = tag;

            List<SelectListItem> country = (from x in context.Countries
                                            select new SelectListItem
                                            {
                                                Text = x.CountryName,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.Country = country;

            List<SelectListItem> language = (from x in context.Languages
                                             select new SelectListItem
                                             {
                                                 Text = x.LanguageName,
                                                 Value = x.ID.ToString(),
                                             }).ToList();
            ViewBag.Language = language;

            var editLead=context.Leads.Where(x=>x.ID==id).FirstOrDefault();
            return View(editLead);
        }

        [HttpPost]
        public ActionResult EditLead(Lead lead)
        {
            var editLead = context.Leads.Where(x => x.ID == lead.ID).FirstOrDefault();
            editLead.LeadStatusID= lead.LeadStatusID;
            editLead.LeadSourceID= lead.LeadSourceID;
            editLead.AssignedID= lead.AssignedID;
            editLead.TagID= lead.TagID;
            editLead.Name= lead.Name;
            editLead.Address= lead.Address;
            editLead.Position= lead.Position;
            editLead.City= lead.City;
            editLead.Email= lead.Email;
            editLead.State= lead.State;
            editLead.Website= lead.Website;
            editLead.CountryID= lead.CountryID;
            editLead.Phone= lead.Phone;
            editLead.ZipCode= lead.ZipCode;
            editLead.LeadValue= lead.LeadValue;
            editLead.LanguageID= lead.LanguageID;
            editLead.Company= lead.Company;
            editLead.Description= lead.Description;
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var delete =context.Leads.Where(x=>x.ID == id).FirstOrDefault();
            delete.isDeleted = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListLead(int id)
        {
            var leadDetail=context.Leads.Where(x=>x.ID==id).ToList();
            return View(leadDetail);
        }

        public ActionResult LeadPDF()
        {
            var leads=context.Leads.Where(x=>x.isDeleted==false).ToList();
            return View(leads);
        }
    }
}