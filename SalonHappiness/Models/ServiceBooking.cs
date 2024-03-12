using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonHappiness.Models
{
    public class ServiceBooking
    {
        public int ServiceBookingId { get; set; }
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}