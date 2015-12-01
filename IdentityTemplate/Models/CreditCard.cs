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

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [Required]
        [Display(Name ="Card Name")]
        public string CardName { get; set; }

        [Required]
        [CreditCardAttribute]
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