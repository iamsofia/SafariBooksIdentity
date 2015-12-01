using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityTemplate.Models
{
    public class CreditCard
    {
        public int CreditCardID { get; set; }

        //public int CustomerID { get; set; }
        //[ForeignKey("Customer ID")]
        //public virtual Customer Customer { get; set; }

        public virtual AppUser User { get; set; }

        
        [Required]
        [Display(Name ="Card Name")]
        public string CardName { get; set; }

        //Show only last 4 digits
        [Required]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card Number has 16 digits")]
        public string CardNumber { get; set; }

        public enum CreditTypes
        {
            Visa,
            AmericanExpress,
            Discover,
            MasterCard
        };

        public CreditTypes CardType { get; set; }
    }
}