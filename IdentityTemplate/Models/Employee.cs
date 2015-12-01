using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityTemplate.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        //need to grab just employee users

        public string Email { get; set; }
        [ForeignKey("Email")]
        public virtual RegisterViewModel EmployeeEmail { get; set; }
        

    }
}