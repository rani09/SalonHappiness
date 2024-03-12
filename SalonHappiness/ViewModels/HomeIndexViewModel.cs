using SalonHappiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonHappiness.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<FrontPage> FrontPages { get; set; }
        public FrontPage FrontPage { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public Booking Booking { get; set; }
        public List<Service> Services { get; set; }
        public OpenOrClosse OpenOrClosse { get; set; }
    }
}