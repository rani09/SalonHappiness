using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Web;

namespace SalonHappiness.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        [Display(Name = "Dit navn")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Arbejdsstilling")]
        public string Title { get; set; }
        [Display(Name = "Facebook Link")]
        public string Facebook { get; set; }
        [Display(Name = "Instagram Link")]
        public string Instagram { get; set; }
        [Display(Name = "Youtube Link")]
        public string Youtube { get; set; }
        [Display(Name = "Twiter Link")]
        public string Twiter { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public virtual ICollection<TeamFile> TeamFiles { get; set; }

    }
}
