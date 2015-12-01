using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityTemplate.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        //should point to identity models

        public virtual AppUser User { get; set; }
        
        
        public int SKU { get; set; }
        [ForeignKey("SKU")]
        public virtual Book Book { get; set; }

        public string CouponID { get; set; }
        [ForeignKey("CouponID")]
        public virtual Coupon Coupon { get; set; }



        
        public virtual List<Book> Books { get; set; }

    }
}