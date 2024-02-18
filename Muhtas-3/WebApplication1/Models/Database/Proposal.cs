using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models.Database
{
    public class Proposal
    {
        public int ProposalID { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Related { get; set; }
        public string Lead { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime OpenTill { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public string DiscountType { get; set; }
        public string Status { get; set; }
        [Required]
        public string To { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
        public string ZipCode { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Qty { get; set; }
        public decimal TotalPrice { get; set; }
        public int AssignedID { get; set; }
        public virtual Assigned Assigned { get; set; }
        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }

        public int ItemID { get; set; }
        public virtual Item Item { get; set; }




    }
}