using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Payment
    {
        public int ID { get; set; }

        public decimal AmountReceived { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public string TransactionID { get; set; }
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}