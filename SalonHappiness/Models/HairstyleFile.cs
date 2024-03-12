using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonHappiness.Models
{
    public class HairstyleFile
    {
        [Key]
        public int HairstyleFileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int HairstyleId { get; set; }
        public virtual Hairstyle Hairstyle { get; set; }
    }
}