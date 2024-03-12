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
    public class OpenOrClossesController : Controller
    {
        private SalonDbContext db = new SalonDbContext();

        // GET: OpenOrClosses
        public ActionResult Index()
        {
            return View(db.OpenOrClosses.ToList());
        }

        // GET: OpenOrClosses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenOrClosse openOrClosse = db.OpenOrClosses.Find(id);
            if (openOrClosse == null)
            {
                return HttpNotFound();
            }
            return View(openOrClosse);
        }

        // GET: OpenOrClosses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpenOrClosses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpenOrClosseId,Title,Description,OpenOrLukket")] OpenOrClosse openOrClosse)
        {
            if (ModelState.IsValid)
            {
                db.OpenOrClosses.Add(openOrClosse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(openOrClosse);
        }

        // GET: OpenOrClosses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenOrClosse openOrClosse = db.OpenOrClosses.Find(id);
            if (openOrClosse == null)
            {
                return HttpNotFound();
            }
            return View(openOrClosse);
        }

        // POST: OpenOrClosses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpenOrClosseId,Title,Description,OpenOrLukket")] OpenOrClosse openOrClosse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openOrClosse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(openOrClosse);
        }

        // GET: OpenOrClosses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenOrClosse openOrClosse = db.OpenOrClosses.Find(id);
            if (openOrClosse == null)
            {
                return HttpNotFound();
            }
            return View(openOrClosse);
        }

        // POST: OpenOrClosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpenOrClosse openOrClosse = db.OpenOrClosses.Find(id);
            db.OpenOrClosses.Remove(openOrClosse);
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
