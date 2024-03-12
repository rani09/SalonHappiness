using Microsoft.AspNet.Identity;
using SalonHappiness.Extensions;
using SalonHappiness.Models;
using SalonHappiness.Utility;
using SalonHappiness.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace SalonHappiness.Controllers
{
    [RequireHttps]
    [Authorize]
    public class BookingController : Controller
    {
        private SalonDbContext db = new SalonDbContext();
        // GET: Booking

        [HttpGet]
        public ActionResult CreateBooking()
        {
            var item = db.Services.ToList();
            Create_booking_viewmodel booking = new Create_booking_viewmodel
            {
                Services = item.Select(vm => new Service()
                {
                    ServiceId = vm.ServiceId,
                    Title = vm.Title,
                    Description = vm.Description,
                    Price = vm.Price,
                    Time = vm.Time,
                    IsActive = false
                }).ToList()
            };

            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBooking(Create_booking_viewmodel model)
        {
            Booking booking = new Booking();
            List<ServiceBooking> ServiceBookings = new List<ServiceBooking>();
            if (!ModelState.IsValid)
            {
                booking.UserId = User.Identity.GetUserId();
                booking.ArrivelDate = model.ArrivelDate;
                booking.ArrivelTime = model.ArrivelTime;
                booking.Status = Status.NotArrived;
                booking.DateCreated = DateTime.Now;
                db.Bookings.Add(booking);
                db.SaveChanges();

                foreach (var item in model.Services)
                {
                    if (item.IsActive == true)
                    {
                        ServiceBookings.Add(new ServiceBooking
                        {
                            BookingId = booking.BookingId,
                            ServiceId = item.ServiceId,
                        });
                    }
                }
                foreach (var item in ServiceBookings)
                {
                    db.ServiceBookings.Add(item);
                }
                db.SaveChanges();

                TempData["notify"] = new Helper.Notification()
                {
                    Status = Helper.Notification.NotifyStatus.Success,
                    Title = "Gennemført",
                    Message = "Tak, " + User.Identity.Name + " tiden er booket",
                    MessageEmail = "Bekræftelse er blevet sendt til " + User.Identity.GetUserName()
                };

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/MailTemplate/OrderConfirmation.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", User.Identity.GetUserName());
                string date = Convert.ToString(model.ArrivelDate.ToShortDateString());
                string time = Convert.ToString(model.ArrivelTime.ToShortTimeString());
                body = body.Replace("{date}", date);
                body = body.Replace("{time}", time);
                body = body.Replace("{dateCreated}", DateTime.Now.ToString());

                bool IsSendEmail = SendEmail.EmailSend(User.Identity.GetUserName(), "Salon Happiness", body, true);
                if (IsSendEmail)
                    return RedirectToAction("CreateBooking", "Booking");
            }
            return RedirectToAction("CreateBooking", "Booking");
        }

        public ActionResult _OpenTimes()
        {
            return PartialView(db.Opentimes.ToList());
        }
    }
}