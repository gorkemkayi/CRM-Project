using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class ExpenseCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}