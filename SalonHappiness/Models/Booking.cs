using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonHappiness.Models
{
    public class Booking
    {
        public Booking()
        {
            Status = Status.NotArrived;
            DateCreated = DateTime.Now;
        }
        public int BookingId { get; set; }

        [Display(Name = "Dato")]
        [Required(ErrorMessage = "*Intast dato'en")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivelDate { get; set; }

        [Display(Name = "Tid")]
        [Required(ErrorMessage = "*Intast tid'en")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ArrivelTime { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }

        [Display(Name = "Oprettet")]
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual List<Service> Services { get; set; }

    }

    public enum Status
    {
        [Display(Name = "Ikke ankommet")]
        NotArrived,
        [Display(Name = "Ankommet")]
        Arrived,
        [Display(Name = "Betalt")]
        Paid
    }
}