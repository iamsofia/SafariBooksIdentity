using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityTemplate.Models
{
   
        public class GroupedUserViewModel
        {
            public List<UserViewModel> Customers { get; set; }
            public List<UserViewModel> Users { get; set; }
            public List<UserViewModel> Employees { get; set; }
            public List<UserViewModel> Managers { get; set; }
        }

        public class UserViewModel
        {
            public string Username { get; set; }
            public string Roles { get; set; }
        }
    }

    