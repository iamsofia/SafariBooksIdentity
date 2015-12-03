﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace IdentityTemplate.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AppUser : IdentityUser
    {
     
        //TODO: Put any additional fields that you need for your user here
        //For instance
        public string FName { get; set; }

        public string MI { get; set; }

        public string LName { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public int Zip { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Rating> MyRatings { get; set; }

        public virtual ICollection<Review> MyReviews { get; set; }

        public virtual ICollection<Reorder> Reorders { get; set; } //this is only for employees
        
        
        //This method allows you to create a new user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
               
    }

    public class EmpAppUser : IdentityUser
    {

        //TODO: Put any additional fields that you need for your user here
        //For instance
        public string FName { get; set; }

        public string MI { get; set; }

        public string LName { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public int Zip { get; set; }

        //public bool IsManager { get; set; }


        //This method allows you to create a new user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<EmpAppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }






    }

    //TODO: Here's your db context for the project.  All of your db sets should go in here
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        //TODO:  Add dbsets here, for instance there's one for books
        //Remember, Identity adds a db set for users, so you shouldn't add that one - you will get an error
        public DbSet<Book> Books { get; set; }
        
        
        //TODO: Make sure that your connection string name is correct here.
        public AppDbContext()
            : base("MyDBConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public System.Data.Entity.DbSet<IdentityTemplate.Models.AppRole> AppRoles { get; set; }

        public System.Data.Entity.DbSet<IdentityTemplate.Models.Coupon> Coupons { get; set; }

        public System.Data.Entity.DbSet<IdentityTemplate.Models.RegisterViewModel> RegisterViewModels { get; set; }

        public System.Data.Entity.DbSet<IdentityTemplate.Models.CreditCard> CreditCards { get; set; }

        public System.Data.Entity.DbSet<IdentityTemplate.Models.Review> Reviews { get; set; }
    }
}