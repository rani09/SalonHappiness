using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalonHappiness.Models;

namespace SalonHappiness.Controllers
{
    [Authorize(Roles = "User, Administrator")]
    public class SamtykkesController : Controller
    {
        private SalonDbContext db = new SalonDbContext();

        // GET: Samtykkes
        public ActionResult Index()
        {
            return View(db.Samtykkes.ToList());
        }

        // GET: Samtykkes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samtykke samtykke = db.Samtykkes.Find(id);
            if (samtykke == null)
            {
                return HttpNotFound();
            }
            return View(samtykke);
        }

        // GET: Samtykkes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Samtykkes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SamtykkeId,SamtykkeDescription,BetingelseDescription")] Samtykke samtykke)
        {
            if (ModelState.IsValid)
            {
                db.Samtykkes.Add(samtykke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(samtykke);
        }

        // GET: Samtykkes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samtykke samtykke = db.Samtykkes.Find(id);
            if (samtykke == null)
            {
                return HttpNotFound();
            }
            return View(samtykke);
        }

        // POST: Samtykkes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SamtykkeId,SamtykkeDescription,BetingelseDescription")] Samtykke samtykke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(samtykke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samtykke);
        }

        // GET: Samtykkes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samtykke samtykke = db.Samtykkes.Find(id);
            if (samtykke == null)
            {
                return HttpNotFound();
            }
            return View(samtykke);
        }

        // POST: Samtykkes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samtykke samtykke = db.Samtykkes.Find(id);
            db.Samtykkes.Remove(samtykke);
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
