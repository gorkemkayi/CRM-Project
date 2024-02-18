using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Group
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public bool isDeleted { get; set; }
    }
}