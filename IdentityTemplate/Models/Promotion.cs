using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.Models
{
    public class Promotion
    {
        public string PromotionID { get; set; }

        public int SKU { get; set; }
        [ForeignKey("SKU")]
        public virtual Book Book { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}