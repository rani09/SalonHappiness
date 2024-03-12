using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonHappiness.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "*Title skal udfyldes")]
        public string Title { get; set; }

        [Display(Name = "Beskrivelse")]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Tid")]
        [Required(ErrorMessage = "*Tid skal udfyldes")]
        public int Time { get; set; }

        [Display(Name = "Pris")]
        [Required(ErrorMessage = "*Pris skal udfyldes")]
        public decimal Price { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}