using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityTemplate.Models
{
    public class Customer 
    {
        public int CustomerID { get; set; }

        //how to link to aspnet users table? 
        //or link using aspnetuserroles?

        public string Email { get; set; }
        [ForeignKey("Email")]
        public virtual RegisterViewModel CustomerEmail { get; set; }
        
        //can't remember why we have this fk here, commenting out for now - Sofia
        //public int SKU { get; set; }
        //[ForeignKey("SKU")]
        //public virtual Book Book { get; set; }



        //asp net user table has a lockout field
        //public bool CustomerActive { get; set; }

        public virtual List<CreditCard> CreditCards { get; set; }

    }
}