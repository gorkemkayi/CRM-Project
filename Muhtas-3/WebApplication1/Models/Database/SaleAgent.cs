using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class SaleAgent
    {
        public int SaleAgentID { get; set; }
        public string Name { get; set; }

        public ICollection<Estimate> Estimates { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}