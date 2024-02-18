using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class LeadSource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Lead> Leads { get; set; }
        public bool isDeleted { get; set; }
    }
}