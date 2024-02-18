using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Currency
    {
        public int ID { get; set; }
        public string CurrencyName { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Proposal> Proposals { get; set; }
        public ICollection<Estimate> Estimates { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}