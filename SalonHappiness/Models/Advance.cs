using SalonHappiness.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonHappiness.Models
{
    public class Advance
    {
        [Key]
        public int AdvanceId { get; set; }
        [Required]
        [DisplayName("Overskift")]
        public string Headline { get; set; }
        [Required]
        [DisplayName("Under Overskift")]
        public string SubHeadline { get; set; }
        [Required]
        [DisplayName("Icon")]
        public AdvanceIcon IconType { get; set; }
        public bool Active { get; set; }
    }
}