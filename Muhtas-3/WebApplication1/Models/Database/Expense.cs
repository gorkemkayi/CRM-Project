using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Expense
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int Amount { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public int CurrencyID { get; set; }
        public virtual Currency Currency { get; set; }

        public int TaxID { get; set; }
        public virtual Tax Tax { get; set; }

        public string PaymentMode { get; set; }

        public string Reference { get; set; }
        public int ExpenseCategoryID { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }

        public bool isDeleted { get; set; }
    }
}