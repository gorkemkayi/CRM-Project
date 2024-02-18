using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Member
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}