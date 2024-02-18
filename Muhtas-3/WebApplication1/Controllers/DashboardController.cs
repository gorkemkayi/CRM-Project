using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Database;
using WebApplication1.Models.Database.DashboardGroups;

namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        Context context = new Context();
        public ActionResult Index()
        {
            var statusPaidCount = from x in context.Invoices
                                  group x by x.Status into g
                                  select new InvoiceGrup
                                  {
                                      Status = g.Key,
                                      StatusCount = g.Count(),
                                  };

            var estimateDashboard = from x in context.Estimates
                                    group x by x.Status into g
                                    select new EstimateGrup
                                    {
                                        StatusName = g.Key,
                                        statusCount = g.Count(),
                                    };

            var proposalDashBoard = from x in context.Proposals
                                    group x by x.Status into g
                                    select new ProposalGrup
                                    {
                                        StatusName = g.Key,
                                        StatusCount = g.Count(),
                                    };

            var projectDashboard = from x in context.Projects
                                   select new ProjectGroup
                                   {
                                       statusName = x.Status,
                                       projectName = x.ProjectName,
                                       projectDate = x.StartDate.ToString(),
                                       projectDeadline = x.Deadline.ToString(),
                                   };

            var projectStatusDashboard = from x in context.Projects
                                         group x by x.Status into g
                                         select new ProjectStatusGroup
                                         {
                                             ProjectStatusName = g.Key,
                                             StatusCount = g.Count(),
                                         };

            var leadDashboard = from x in context.Leads
                                group x by x.LeadStatus.Name into g
                                select new LeadGroup
                                {
                                    LeadStatusName = g.Key,
                                    LeadStatusCount = g.Count(),
                                };

            


            


            var viewModel = new DashboardViewModel
            {
                StatusPaidCount = statusPaidCount.ToList(),
                EstimateDashboard = estimateDashboard.ToList(),
                ProposalDashboard = proposalDashBoard.ToList(),
                ProjectDashboard = projectDashboard.ToList(),
                ProjectStatusDashboard = projectStatusDashboard.ToList(),
                LeadDashboard = leadDashboard.ToList(),
            };

            return View(viewModel);
        }
    }
}