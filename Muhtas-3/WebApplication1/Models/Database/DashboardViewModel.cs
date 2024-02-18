using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Database.DashboardGroups;

namespace WebApplication1.Models.Database
{
    public class DashboardViewModel
    {
        public List<InvoiceGrup> StatusPaidCount { get; set; }
        public List<EstimateGrup> EstimateDashboard { get; set; }
        public List<ProposalGrup> ProposalDashboard { get; set; }
        public List<ProjectGroup> ProjectDashboard { get; set; }
        public List<ProjectStatusGroup> ProjectStatusDashboard { get; set; }
        public List<ProjectGraph> ProjectGraph { get; set; }
        public List<LeadGroup> LeadDashboard { get; set; }

    }
}