using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IdentityTemplate.Models;

namespace IdentityTemplate.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
            : base("MyDBConnection")
        { }
    }
}