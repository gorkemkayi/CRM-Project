using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Support> Supports { get; set; }
        public string Email { get; set; }
        public bool isDeleted { get; set; }
    }
}