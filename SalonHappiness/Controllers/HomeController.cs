using SalonHappiness.Models;
using System.Net;
using System.Net.Mail;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SalonHappiness.ViewModels;
using Microsoft.AspNet.Identity;
using SalonHappiness.Extensions;
using System.IO;
using SalonHappiness.Utility;

namespace SalonHappiness.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private SalonDbContext db = new SalonDbContext();

        public ActionResult Index()
        {
            var frontpage = db.FrontPages.FirstOrDefault();
            if (frontpage != null)
            {
                ViewBag.FrontTitle = frontpage.Title;
                ViewBag.Description = frontpage.Description;
                ViewBag.FrontPageFiles = frontpage.FrontPageFiles;
                ViewBag.Active = frontpage.Active;
            }
            var viewmodel = new HomeIndexViewModel
            {
                FrontPage = frontpage,
                FrontPages = db.FrontPages.ToList(),
                Bookings = db.Bookings.ToList(),
                Booking = db.Bookings.FirstOrDefault(),
                Services = db.Services.ToList(),
                OpenOrClosse = db.OpenOrClosses.FirstOrDefault(),

            };

            return View(viewmodel);
        }

        public ActionResult _FrontPage()
        {
            return PartialView(db.FrontPages.ToList());
        }

        public ActionResult _Hairstyles()
        {
            return PartialView(db.Hairstyles.ToList());
        }
        public ActionResult About()
        {
            return View(db.AboutUs.ToList());
        }

        public ActionResult _Open()
        {
            return PartialView(db.Opentimes.ToList());
        }
        public ActionResult _Advance()
        {
            return PartialView(db.Advances.ToList());
        }
        public ActionResult _AboutUs()
        {
            return PartialView(db.AboutUs.ToList());
        }
        public ActionResult _Teams()
        {
            return PartialView(db.Teams.ToList());
        }
        public ActionResult _Contract()
        {
            return PartialView(db.Contracts.ToList());
        }
        public ActionResult _Price()
        {
            return PartialView(db.Prices.Where(x => x.Active).ToList());
        }
        public ActionResult _Contact()
        {
            return PartialView(db.Contracts.ToList());
        }
        public ActionResult _ContactText()
        {
            return PartialView(db.Contracts.ToList());
        }
        public ActionResult _Samtykke()
        {
            return PartialView(db.Samtykkes.ToList());
        }
        public ActionResult _Betingelse()
        {
            return PartialView(db.Samtykkes.ToList());
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email Fra: {0} ({1})</p><p>Besked:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("info@salonhappiness.dk"));  // replace with valid value 
                message.From = new MailAddress("info@salonhappiness.dk");  // replace with valid value
                message.Subject = "Din email emne";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "info@salonhappiness.dk",  // replace with valid value
                        Password = "salonhappiness2020"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.simply.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    TempData["mailsendt"] = new Helper.Notification()
                    {
                        Status = Helper.Notification.NotifyStatus.Success,
                        Title = "Sendt",
                        Message = "Tak, " + model.FromEmail + " beskeden er sendt",
                        MessageEmail = "Du hører fra os indenfor en arbejdsdag. Vi sender dig en mail til" + model.FromEmail
                    };
                    return RedirectToAction("Contact", "Home");
                }
            }
            return View(model);
        }
        public ActionResult Samtykke()
        {
            return View(db.Contracts.ToList());
        }

    }
}