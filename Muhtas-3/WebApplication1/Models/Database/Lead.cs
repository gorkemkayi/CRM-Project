using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Lead
    {
        public int ID { get; set; }
        public int LeadStatusID { get; set; }
        public virtual LeadStatus LeadStatus { get; set; }
        public int LeadSourceID { get; set; }
        public virtual LeadSource LeadSource { get; set; }
        public int AssignedID { get; set; }
        public virtual Assigned Assigned { get; set; }

        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Website { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public decimal LeadValue { get; set; }
        public int LanguageID { get; set; }
        public virtual Language Language { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
    }
}