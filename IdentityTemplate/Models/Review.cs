using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        //  1:N 
        //SKU: Review

        public int SKU { get; set; }
        [ForeignKey("SKU")]
        public virtual Book Book { get; set; }

        public string CustomerReview { get; set; }

        public virtual AppUser User { get; set; }


        [Display(Name="Approve/Reject")]
        public bool ReviewApproval { get; set; }

        public int AverageRating { get; set; }
    }
}