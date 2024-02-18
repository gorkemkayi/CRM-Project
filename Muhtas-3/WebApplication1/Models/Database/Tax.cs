using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Tax
    {
        public int TaxID { get; set; }
        public string TaxName { get; set; }
        public decimal TaxValue { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public bool isDeleted { get; set; }
    }
}