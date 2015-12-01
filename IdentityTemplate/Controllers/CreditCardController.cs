using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityTemplate.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace IdentityTemplate.Controllers
{
    public class CreditCardController : Controller
    {
        private AppDbContext db;
        private UserManager<AppUser> manager;

        public CreditCardController()
        {
            db = new AppDbContext();
            manager = new UserManager<AppUser>(new UserStore<AppUser>(db));

        }

        // GET: /CreditCard/
        //Get CreditCard(s) for the logged in user
        public ActionResult Index()
        {
           
            var currentUser = manager.FindById(User.Identity.GetUserId());
            return View(db.CreditCards.ToList().Where(creditcard => creditcard.User.Id == currentUser.Id));

        }

        // GET: /ToDo/All
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> All()
        {
            return View(await db.CreditCards.ToListAsync());
        }

        // GET: /CreditCard/Details/5
        public async Task<ActionResult> Details(int? id) 
        {
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId()); //mod
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditcard = await db.CreditCards.FindAsync(id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            if (creditcard.User.Id != currentUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            return View(creditcard);
        }

        // GET: /CreditCard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CreditCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="User_Id, CreditCardID,CardName,CardNumber,CardType")] CreditCard creditcard)
        {
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId()); 
            if (ModelState.IsValid)
            {
                creditcard.User = currentUser;
                db.CreditCards.Add(creditcard);
                await db.SaveChangesAsync();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(creditcard);
        }

        // GET: /CreditCard/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId()); 
            if (id == null)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditcard = await db.CreditCards.FindAsync(id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            if (creditcard.User.Id != currentUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            return View(creditcard);
        }

        // POST: /CreditCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "User_Id,CreditCardID,CardName,CardNumber,CardType")] CreditCard creditcard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditcard).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(creditcard);
        }

        // GET: /CreditCard/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId()); 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditcard =  await db.CreditCards.FindAsync(id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            if (creditcard.User.Id != currentUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            return View(creditcard);
        }

        // POST: /CreditCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CreditCard creditcard = await db.CreditCards.FindAsync(id);
            db.CreditCards.Remove(creditcard);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
