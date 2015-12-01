using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.Models
{
    public class Rating
    {
        public int RatingID { get; set; }

        //  1:N  
        //SKU: Rating

        public int SKU { get; set; }
        [ForeignKey("SKU")]
        public virtual Book Book { get; set; }

        public int CustomerRating { get; set; }

        //how to calculate average?

    }
}