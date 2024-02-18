using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Admin
    {
        public int AdminID { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isDeleted { get; set; }
    }
}