using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database.DashboardGroups
{
    public class ProjectGroup
    {
        public string projectName { get; set; }
        public string projectDate { get; set; }
        public string projectDeadline { get; set; }
        public string statusName { get; set; }
    }
}