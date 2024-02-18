using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Contract
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public string Subject { get; set; }
        public int ContractValue { get; set; }

        public int ContractTypeID { get; set; }
        public virtual ContractType ContractType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
    }
}