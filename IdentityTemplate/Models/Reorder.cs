using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IdentityTemplate.Models;

namespace IdentityTemplate.Models
{
    public class Reorder
    {
        public int ReorderID { get; set; }

        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        public int SKU { get; set; }
        [ForeignKey("SKU")]
        public virtual Book Book { get; set; }

    }
}