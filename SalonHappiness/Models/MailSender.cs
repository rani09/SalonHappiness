using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SalonHappiness.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Dit navn")]
        public string FromName { get; set; }

        [Required, Display(Name = "Din email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required, Display(Name = "Din besked")]
        public string Message { get; set; }
    }
}