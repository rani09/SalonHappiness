using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonHappiness.Models
{
    public class Opentime
    {
        public int OpentimeId { get; set; }

        [Display(Name = "Dag")]
        [Required(ErrorMessage = "Dag er påkrævet")]
        public string Day { get; set; }

        [Display(Name = "Dag-Navn på engelsk")]
        [Required(ErrorMessage = "Dag-Navn er påkrævet")]
        public string DayName { get; set; }
        [Display(Name = "Åben")]
        [Required(ErrorMessage = "Åben er påkrævet")]
        public string Open { get; set; }
        [Display(Name = "Lukket")]
        [Required(ErrorMessage = "Lukket er påkrævet")]
        public string Closed { get; set; }
    }
}