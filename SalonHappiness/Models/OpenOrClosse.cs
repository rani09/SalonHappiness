using SalonHappiness.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonHappiness.Models
{
    public class OpenOrClosse
    {
        public int OpenOrClosseId { get; set; }
        [Required]
        [DisplayName("Titel")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayName("Type")]
        public OpenOrCloseType OpenOrLukket { get; set; }

    }
}