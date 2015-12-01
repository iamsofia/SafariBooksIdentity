using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityTemplate.Models;

namespace IdentityTemplate.Controllers
{
    public class CreditCardController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: /CreditCard/
        public ActionResult Index()
        {
            var creditcards = db.CreditCards.Include(c => c.Customer);
            return View(creditcards.ToList());
        }

        // GET: /CreditCard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditcard = db.CreditCards.Find(id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            return View(creditcard);
        }

        // GET: /CreditCard/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Email");
            return View();
        }

        // POST: /CreditCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CreditCardID,CustomerID,CardName,CardNumber,CardType")] CreditCard creditcard)
        {
            if (ModelState.IsValid)
            {
                db.CreditCards.Add(creditcard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Email", creditcard.CustomerID);
            return View(creditcard);
        }

        // GET: /CreditCard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditcard = db.CreditCards.Find(id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Email", creditcard.CustomerID);
            return View(creditcard);
        }

        // POST: /CreditCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CreditCardID,CustomerID,CardName,CardNumber,CardType")] CreditCard creditcard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditcard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Email", creditcard.CustomerID);
            return View(creditcard);
        }

        // GET: /CreditCard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditcard = db.CreditCards.Find(id);
            if (creditcard == null)
            {
                return HttpNotFound();
            }
            return View(creditcard);
        }

        // POST: /CreditCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditCard creditcard = db.CreditCards.Find(id);
            db.CreditCards.Remove(creditcard);
            db.SaveChanges();
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
