using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonHappiness.Models
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Pris")]
        public decimal Pricing { get; set; }

        [DisplayName("Rabat I Procent")]
        public string DiscountPrice { get; set; }
        [DisplayName("Rabat title")]
        public string DiscountTitle { get; set; }

        [DisplayName("Aktiv Rabat")]
        public bool DiscountActive { get; set; }

        [Required]
        [DisplayName("Aktiv")]
        public bool Active { get; set; }
    }
}