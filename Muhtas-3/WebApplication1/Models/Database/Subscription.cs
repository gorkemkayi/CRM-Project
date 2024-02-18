using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Subscription
    {
        public int ID { get; set; }
        public string BillingPlan { get; set; }
        public int Qty { get; set; }
        public DateTime FirstBillingDate { get; set; }
        public string SubName { get; set; }
        public string Description { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public int CurrencyID { get; set; }
        public virtual Currency Currency { get; set; }

        public int TaxID { get; set; }
        public virtual Tax Tax { get; set; }

        public bool Status { get; set; }

        public bool isDeleted { get; set; }
    }
}