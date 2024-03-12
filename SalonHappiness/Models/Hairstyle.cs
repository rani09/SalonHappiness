using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalonHappiness.Models
{
    public class Hairstyle
    {
        [Key]
        public int HairstyleId { get; set; }
        [Required]
        [Display(Name = "Person navn")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "By")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Dato")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<HairstyleFile> HairstyleFiles { get; set; }
    }
}