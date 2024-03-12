using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonHappiness.Models
{
    public class AboutUs
    {
        [Key]
        public int AboutUsId { get; set; }
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Beskrivelse")]
        [AllowHtml]
        public string Description { get; set; }
        public virtual ICollection<AboutUsFile> AboutUsFiles { get; set; }

    }
}
