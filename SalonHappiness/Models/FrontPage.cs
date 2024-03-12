using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonHappiness.Models
{
    public class FrontPage
    {
        [Key]
        public int FrontPageId { get; set; }
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Beskrivelse")]
        [AllowHtml]
        public string Description { get; set; }

        [DisplayName("Aktiv")]
        public bool Active { get; set; }
        public virtual ICollection<FrontPageFile> FrontPageFiles { get; set; }
    }
}