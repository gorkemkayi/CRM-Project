using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Assigned
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Proposal> Proposals { get; set; }
        public ICollection<Lead> Leads { get; set; }
    }
}