using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Support
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public string CC { get; set; }
        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }
        public string AssignTicket { get; set; }
        //public string Priority { get; set; }
        public string Service { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public string Message { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<Reply> Replies { get; set; }

        public int SupportStatusID { get; set; }
        public virtual SupportStatus SupportStatus { get; set; }

        public int PriorityID { get; set; }
        public virtual Priority Priority { get; set; }

    }
}