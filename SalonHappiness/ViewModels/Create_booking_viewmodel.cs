using SalonHappiness.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonHappiness.ViewModels
{
    public class Create_booking_viewmodel
    {
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
}