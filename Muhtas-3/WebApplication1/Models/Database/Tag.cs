using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }
        public ICollection<Proposal> proposals { get; set; }
        public ICollection<Estimate> Estimates { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Support> Supports { get; set; }
        public ICollection<Lead> Leads { get; set; }
    }
}