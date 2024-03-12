using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonHappiness.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        [Required]
        [DisplayName("Salon Navn")]
        public string SalonName { get; set; }
        [Required]
        [DisplayName("Stilling")]
        public string Position { get; set; }
        [Required]
        [DisplayName("Beskrivelse")]
        public string Description { get; set; }
        [Required]
        [DisplayName("By")]
        public string City { get; set; }
        [Required]
        [DisplayName("Adresse")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Post Nummer")]
        public string Postalcode { get; set; }
        [Required]
        [DisplayName("Telefon")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Mobil")]
        public string Mobile { get; set; }
        [Required]
        [DisplayName("Salon E-mail")]
        public string Email { get; set; }
        [Required]
        [DisplayName("E-mail tekst")]
        public string EmailText { get; set; }
        [Required]
        [DisplayName("CVR-nummer")]
        public string CVR { get; set; }
    }
}