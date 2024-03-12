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
    public class AdvancesController : Controller
    {
        private SalonDbContext db = new SalonDbContext();

        // GET: Advances
        public ActionResult Index()
        {
            return View(db.Advances.ToList());
        }

        // GET: Advances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advance advance = db.Advances.Find(id);
            if (advance == null)
            {
                return HttpNotFound();
            }
            return View(advance);
        }

        // GET: Advances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvanceId,Headline,SubHeadline,IconType,Active")] Advance advance)
        {
            if (ModelState.IsValid)
            {
                db.Advances.Add(advance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advance);
        }

        // GET: Advances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advance advance = db.Advances.Find(id);
            if (advance == null)
            {
                return HttpNotFound();
            }
            return View(advance);
        }

        // POST: Advances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdvanceId,Headline,SubHeadline,IconType,Active")] Advance advance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advance);
        }

        // GET: Advances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advance advance = db.Advances.Find(id);
            if (advance == null)
            {
                return HttpNotFound();
            }
            return View(advance);
        }

        // POST: Advances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advance advance = db.Advances.Find(id);
            db.Advances.Remove(advance);
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
