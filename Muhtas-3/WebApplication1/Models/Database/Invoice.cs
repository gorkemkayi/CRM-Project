using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Invoice
    {
        public int ID { get; set; }
        public string InvoiceNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PaymentMethod { get; set; }
        public int CurrencyID { get; set; }
        public virtual Currency Currency { get; set; }
        public int SaleAgentID { get; set; }
        public virtual SaleAgent SaleAgent { get; set; }
        public string RecurringInvoice { get; set; }
        public string DiscountType { get; set; }
        public string AdminNote { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalTax { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public string Project { get; set; }
        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public bool DeleteInvoice { get; set; }

        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
        public int Qty { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}