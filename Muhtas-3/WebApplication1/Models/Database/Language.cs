using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Language
    {
        public int ID { get; set; }
        public string LanguageName { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Lead> Leads { get; set; }
    }
}