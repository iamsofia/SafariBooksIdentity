using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace IdentityTemplate.Models
{
    public class Coupon
    {

        [Key]
        [Required]
        [Display(Name = "Coupon Code")]
        //must be between 1 and 20 characters (letters and numbers)
        [StringLength(20, ErrorMessage = "the Coupon Code must be must be between 1 and 20 characters")]
        public string CouponID { get; set; }

        public bool Active { get; set; }


        [Display(Name = "Conditional Free Shpping")]
        public bool FreeShipIf { get; set; }

        [Display(Name = "Free Shipping Off All Orders")]
        public bool FreeShipAll { get; set; }

        [Display(Name = "Apply Discount to Total")]
        public bool DiscountTotal { get; set; }



        public decimal? Discount { get; set; }

        public decimal? OrderThreshold { get; set; }




    }

}