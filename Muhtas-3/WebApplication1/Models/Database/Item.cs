using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }        
        public int Unit { get; set; }
        //public string ItemGroup { get; set; }

        public ICollection<Proposal> Proposals { get; set; }

        public int? TaxID { get; set; }
        public virtual Tax Tax { get; set; }

        public ICollection<Estimate> Estimates { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        public int? ItemGroupID { get; set; }
        public virtual ItemGroup ItemGroup { get; set; }


    }
}