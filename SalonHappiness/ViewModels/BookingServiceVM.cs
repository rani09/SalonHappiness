using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonHappiness.ViewModels
{
    public class BookingServiceVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }
        public decimal Price { get; set; }
        public bool Assigned { get; set; }
    }
}