using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonHappiness.Models
{
    public class Samtykke
    {
        public int SamtykkeId { get; set; }

        [Required]
        [DisplayName("Samtykke")]
        [AllowHtml]
        public string SamtykkeDescription { get; set; }

        [Required]
        [DisplayName("Betingelse")]
        [AllowHtml]
        public string BetingelseDescription { get; set; }
    }
}