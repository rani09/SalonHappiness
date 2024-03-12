using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SalonHappiness.Models;

namespace SalonHappiness.Controllers
{
    [Authorize(Roles = "User, Administrator")]
    public class BookingsController : Controller
    {
        private SalonDbContext db = new SalonDbContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.User);
            return View(bookings.Where(x => x.ArrivelDate == DateTime.Today).OrderBy(d => d.ArrivelTime).ToList());

        }
        public ActionResult GetBookings(string query, int? Page)
        {
            var bookings = db.Bookings.Include(b => b.User).ToList();
            DateTime dateValue;
            if (!string.IsNullOrEmpty(query))
            {
                if (DateTime.TryParse(query, out dateValue))
                {
                    bookings = bookings.Where(x => x.ArrivelDate.ToString().Contains(dateValue.ToShortDateString())).ToList();
                }
                else
                {
                    bookings = bookings.Where(x => x.User.Fname.Contains(query)).ToList();
                }
            }
            Thread.Sleep(3000);
            return View(bookings.ToPagedList(Page ?? 1, 10));
        }
        public ActionResult _OneWeek(int? Page)
        {
            var bookings = db.Bookings.Include(b => b.User);
            return PartialView(bookings.Where(x => x.ArrivelDate > DateTime.Today).OrderBy(d => d.ArrivelDate).ToList().ToPagedList(Page ?? 1, 8));
        }
        public ActionResult _Finished(int? Page)
        {
            var bookings = db.Bookings.Include(b => b.User);
            return PartialView(bookings.Where(x => x.ArrivelDate < DateTime.Today).OrderBy(d => d.ArrivelDate).ToList().ToPagedList(Page ?? 1, 8));
        }
        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Fname");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,ArrivelDate,ArrivelTime,Status,DateCreated,UserId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Fname", booking.UserId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Fname", booking.UserId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,ArrivelDate,ArrivelTime,Status,DateCreated,UserId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Fname", booking.UserId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
