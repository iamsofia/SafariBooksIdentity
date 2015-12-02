using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

//TODO: Change this reference to your project name
using IdentityTemplate.Models;

namespace IdentityTemplate.Controllers
{
    public class RoleAdminController : Controller
    {
        private AppDbContext db;

        public RoleAdminController()
        {
            db = new AppDbContext();
            //manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        //
        // GET: /RoleAdmin/
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = RoleManager.Create(new AppRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }

            //if code gets this far, we need to show an error
            return View(name);
        }

        public ActionResult Edit(string id)
        {
            AppRole role = RoleManager.FindById(id);
            string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();
            IEnumerable<AppUser> members = UserManager.Users.Where(x => memberIDs.Any(y => y == x.Id));
            IEnumerable<AppUser> nonMembers = UserManager.Users.Except(members);
            return View(new RoleEditModel { Role = role, Members = members, NonMembers = nonMembers });
        }

        [HttpPost]
        public ActionResult Edit(RoleModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    result = UserManager.AddToRole(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }

                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    result = UserManager.RemoveFromRole(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "Role Not Found" });
        }




        private void AddErrorsFromResult(IdentityResult result)
        { 
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        private AppRoleManager RoleManager 
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }

        public ActionResult AllCustomers()
        {
            //AppRole roleName = RoleManager.FindByName(role);

            var allusers = db.Users.ToList();
            var users = allusers.Where(x => x.Roles.Select(role => role.RoleId).Contains("f32fa611-547f-4761-bfa3-9682f677e04c")).ToList();
            var userVM = users.Select(user => new UserViewModel { Username = user.UserName, Roles = string.Join(",", user.Roles.Select(role => role.RoleId)) }).ToList();

            var customers = allusers.Where(x => x.Roles.Select(role => role.RoleId).Contains("04d2547f-4935-4842-add6-a0a1229eae16")).ToList();
            var customersVM = customers.Select(user => new UserViewModel { Username = user.UserName, Roles = string.Join(",", user.Roles.Select(role => role.RoleId)) }).ToList();
            var model = new GroupedUserViewModel { Customers = userVM, Managers = customersVM };

            //var managers = allusers.Where(x => x.Roles.Select(role => role.Name).Contains("Manager")).ToList();
            //var managersVM = managers.Select(user => new UserViewModel { Username = user.FullName, Roles = string.Join(",", user.Roles.Select(role => role.Name)) }).ToList();
            //var model = new GroupedUserViewModel { Customers = userVM, Managers = managersVM };

            return View(model);
        }

       
	}
}