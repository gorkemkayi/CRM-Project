using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ProposalController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var proposal = context.Proposals.ToList();


            return View(proposal);
        }
        [HttpGet]
        public ActionResult AddProposal()
        {


            List<SelectListItem> currency = (from x in context.Currencies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrencyName,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.Currency = currency;

            List<SelectListItem> discountType = new List<SelectListItem>
            {
                new SelectListItem{Text="No Discount",Value="NoDiscount"},
                new SelectListItem{Text="Before Tax",Value="BeforeTax"},
                new SelectListItem{Text="After Text",Value="AfterText"}
            }.ToList();
            ViewBag.DiscountType = discountType;

            List<SelectListItem> status = new List<SelectListItem>
            {
               new SelectListItem{Text="Draft",Value="Draft"},
               new SelectListItem{Text="Sent",Value="Open"},
               new SelectListItem{Text="Revised",Value="Revised"},
               new SelectListItem{Text="Declined",Value="Declined"},
               new SelectListItem{Text="Accepted",Value="Accepted"},
            }.ToList();
            ViewBag.Status = status;

            List<SelectListItem> assigned = (from x in context.Assigneds.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.Assigned = assigned;

            List<SelectListItem> country = (from x in context.Countries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CountryName,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.Country = country;

            List<SelectListItem> tag = (from x in context.Tags.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.TagID.ToString()
                                        }).ToList();
            ViewBag.Tag = tag;

            List<SelectListItem> item = (from x in context.Items.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.ItemID.ToString()
                                         }).ToList();
            ViewBag.Item = item;


            List<SelectListItem> tax = (from x in context.Taxes.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.TaxValue.ToString(),
                                            Value = x.TaxID.ToString()
                                        }).ToList();
            ViewBag.Taxes = tax;

            List<SelectListItem> itemGroup = new List<SelectListItem>
            {
                new SelectListItem{Text="Products",Value="Products"},
                new SelectListItem{Text="Services",Value="Services"}
            }.ToList();
            ViewBag.ItemGroup = itemGroup;


            return View();
        }
        [HttpPost]
        public ActionResult AddProposal(Proposal proposal)
        {
            context.Proposals.Add(proposal);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditProposal(int id)
        {
            List<SelectListItem> currency = (from x in context.Currencies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CurrencyName,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.Currency = currency;

            List<SelectListItem> discountType = new List<SelectListItem>
            {
                new SelectListItem{Text="No Discount",Value="NoDiscount"},
                new SelectListItem{Text="Before Tax",Value="BeforeTax"},
                new SelectListItem{Text="After Text",Value="AfterText"}
            }.ToList();
            ViewBag.DiscountType = discountType;

            List<SelectListItem> tag=(from x in context.Tags.ToList()
                                      select new SelectListItem
                                      {
                                          Text=x.Name,
                                          Value=x.TagID.ToString()
                                      }).ToList() ;
            ViewBag.Tag = tag;

            List<SelectListItem> status = new List<SelectListItem>
            {
               new SelectListItem{Text="Draft",Value="Draft"},
               new SelectListItem{Text="Sent",Value="Open"},
               new SelectListItem{Text="Revised",Value="Revised"},
               new SelectListItem{Text="Declined",Value="Declined"},
               new SelectListItem{Text="Accepted",Value="Accepted"},
            }.ToList();
            ViewBag.Status = status;

            List<SelectListItem> assigned = (from x in context.Assigneds.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.Assigned = assigned;
            List<SelectListItem> country = (from x in context.Countries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CountryName,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.Country = country;

            List<SelectListItem> item = (from x in context.Items.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.ItemID.ToString()
                                         }).ToList();
            ViewBag.Item = item;


            var editproposal=context.Proposals.Where(x=>x.ProposalID==id).FirstOrDefault();
            return View(editproposal);
        }

        public ActionResult EditProposal(Proposal proposal)
        {
            var editProposal=context.Proposals.Where(x=>x.ProposalID!=proposal.ProposalID).FirstOrDefault();
            editProposal.Subject= proposal.Subject;
            editProposal.Related= proposal.Related;
            editProposal.Date= proposal.Date;
            editProposal.OpenTill= proposal.OpenTill;
            editProposal.Currency= proposal.Currency;
            editProposal.DiscountType= proposal.DiscountType;
            editProposal.Tag= proposal.Tag;
            editProposal.Status= proposal.Status;
            editProposal.Assigned= proposal.Assigned;
            editProposal.To= proposal.To;
            editProposal.Address= proposal.Address;
            editProposal.City= proposal.City;
            editProposal.State= proposal.State;
            editProposal.Country= proposal.Country;
            editProposal.ZipCode= proposal.ZipCode;
            editProposal.Email= proposal.Email;
            editProposal.Phone= proposal.Phone;
            editProposal.ItemID= proposal.ItemID;
            editProposal.Qty= proposal.Qty;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        

        public ActionResult ProposalPDF()
        {
            var proposals = context.Proposals.ToList();
            return View(proposals);
        }



    }
}