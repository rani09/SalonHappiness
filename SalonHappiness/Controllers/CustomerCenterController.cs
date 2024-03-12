using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
using SalonHappiness.Models;
using SalonHappiness.ViewModels;

namespace SalonHappiness.Controllers
{
    [Authorize]
    [RequireHttps]
    public class CustomerCenterController : Controller
    {
        private SalonDbContext db = new SalonDbContext();

        // GET: BookingUser
        public ActionResult BookingAccount(int? Page)
        {
            var userId = User.Identity.GetUserId();
            var bookings = db.Bookings.Include(b => b.User);
            return View(bookings.Where(s => s.UserId == userId).OrderByDescending(d => d.ArrivelDate).ToList().ToPagedList(Page ?? 1, 10));
        }
        public ActionResult BooketTime(int? Page)
        {
            var userId = User.Identity.GetUserId();
            var bookings = db.Bookings.Include(b => b.User);
            return View(bookings.Where(x => x.UserId == userId && x.ArrivelDate == DateTime.Today || x.ArrivelDate > DateTime.Now).OrderByDescending(d => d.ArrivelDate).ToList().ToPagedList(Page ?? 1, 10));
        }
        public ActionResult _CustommerMenu()
        {
            var userId = User.Identity.GetUserId();
            var bookings = db.Bookings.Include(b => b.User);
            return PartialView(bookings.Where(x => x.UserId == userId).ToList());
        }

        public ActionResult EditBooking(int? bookingId)
        {
            if (bookingId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Include(i => i.Services).Where(x => x.BookingId == bookingId).Single();
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Fname", booking.UserId);
            PopulatesAssigneBatData(booking);
            return PartialView("_EditBooking", booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBooking(Booking booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(booking).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("BooketTime");
                }
                ViewBag.UserId = new SelectList(db.Users, "Id", "Fname", booking.UserId);
                return View(booking);
            }
            catch (Exception)
            {

                throw;
            }

        }
        //[HttpPost]
        //public ActionResult EditBooking(Booking booking)
        //{
        //    try
        //    {
        //        if (booking.BookingId > 0)
        //        {
        //            Booking boo = db.Bookings.SingleOrDefault(x => x.BookingId == booking.BookingId);

        //            boo.ArrivelDate = booking.ArrivelDate;
        //            boo.ArrivelTime = booking.ArrivelTime;
        //            boo.UserId = booking.UserId;
        //            boo.Status = booking.Status;
        //            boo.DateCreated = DateTime.Now;
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            Booking boo = new Booking();
        //            boo.ArrivelDate = booking.ArrivelDate;
        //            boo.ArrivelTime = booking.ArrivelTime;
        //            boo.UserId = booking.UserId;
        //            boo.Status = booking.Status;
        //            boo.UserId = booking.UserId;
        //            boo.DateCreated = booking.DateCreated;
        //            db.Bookings.Add(boo);
        //            db.SaveChanges();

        //        }
        //        return View(booking);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBooking(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("BookingAccount");
        }
        private void PopulatesAssigneBatData(Booking booking)
        {
            var allServices = db.Services;
            var serviceBookings = new HashSet<int>(booking.Services.Select(x => x.ServiceId));
            var viewmodel = new List<BookingServiceVM>();
            foreach (var ser in allServices)
            {
                viewmodel.Add(new BookingServiceVM
                {
                    Id = ser.ServiceId,
                    Title = ser.Title,
                    Description = ser.Description,
                    Price = ser.Price,
                    Time = ser.Time,
                    Assigned = serviceBookings.Contains(ser.ServiceId)
                });
            }
            ViewBag.Services = viewmodel;
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
