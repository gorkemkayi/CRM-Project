using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Project
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public string BillingType { get; set; }

        public string Status { get; set; }
        public decimal TotalRate { get; set; }
        public decimal EstimatedHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }

        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }

        public int MemberID { get; set; }
        public virtual Member Member { get; set; }

        public ICollection<Support> Supports { get; set; }

    }
}