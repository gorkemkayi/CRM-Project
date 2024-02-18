using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Reply
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public int SupportID { get; set; }
        public virtual Support Support { get; set; }
    }
}