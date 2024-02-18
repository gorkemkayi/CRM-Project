using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;

namespace WebApplication1.Controllers
{
    public class ProposalItemController : Controller
    {
        // GET: ProposalItem
        Context context =new Context();
        public ActionResult Index(int id)
        {            
                        
            List<Proposal> proposals=context.Proposals.Where(x=>x.ProposalID==id).ToList();
            foreach (var proposal in proposals)
            {
                var subtotal = proposal.Qty * proposal.Item.Rate;
                var taxAmount = subtotal * proposal.Item.Tax.TaxValue;

                proposal.TotalPrice = subtotal + taxAmount;
            }
            context.SaveChanges();
            
            return View(proposals);
        }
    }
}