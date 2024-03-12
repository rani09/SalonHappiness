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
    public class OpentimesController : Controller
    {
        private SalonDbContext db = new SalonDbContext();

        // GET: Opentimes
        public ActionResult Index()
        {
            return View(db.Opentimes.ToList());
        }

        // GET: Opentimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opentime opentime = db.Opentimes.Find(id);
            if (opentime == null)
            {
                return HttpNotFound();
            }
            return View(opentime);
        }

        // GET: Opentimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opentimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpentimeId,Day,DayName,Open,Closed")] Opentime opentime)
        {
            if (ModelState.IsValid)
            {
                db.Opentimes.Add(opentime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opentime);
        }

        // GET: Opentimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opentime opentime = db.Opentimes.Find(id);
            if (opentime == null)
            {
                return HttpNotFound();
            }
            return View(opentime);
        }

        // POST: Opentimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpentimeId,Day,DayName,Open,Closed")] Opentime opentime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opentime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opentime);
        }

        // GET: Opentimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opentime opentime = db.Opentimes.Find(id);
            if (opentime == null)
            {
                return HttpNotFound();
            }
            return View(opentime);
        }

        // POST: Opentimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opentime opentime = db.Opentimes.Find(id);
            db.Opentimes.Remove(opentime);
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
