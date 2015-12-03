using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityTemplate.Models
{
    public class Book
    
    {
        [Key]
        public int SKU { get; set; }
        public string Title { get; set; }
        public string AuthorFirst { get; set; }
        public string AuthorLast { get; set; }

        public string Genre { get; set; }

        public DateTime PublicationDate { get; set; }

        public decimal Price { get; set; }

        public decimal PriceLastPaid { get; set; }

        public int Inventory { get; set; }

        public int ReorderPoint { get; set; }

        public bool Discontinued { get; set; }

        
        

        //public bool Active { get; set; }


        public virtual List<Review> Reviews { get; set; }
        
    }
}