using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Country
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Proposal> Proposals { get; set; }
        public ICollection<Estimate> Estimates { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Lead> Leads { get; set; }
    }
}