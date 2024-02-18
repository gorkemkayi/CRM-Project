using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication1.Models.Database
{
    public class Customer
    {
        public int ID { get; set; }
        [Required]
        public string Company { get; set; }
        public int VatNumber { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        //public string Groups { get; set; }
        //public string Currency { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool Status { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency Currency  { get; set; }

        public virtual ICollection<Estimate> Estimates { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        public ICollection<Subscription> subscriptions { get; set; }

        public ICollection<Expense> Expenses { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}