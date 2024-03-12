using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace SalonHappiness.Extensions
{
    public class Helper
    {
        public class Notification
        {
            public NotifyStatus Status { get; set; }

            public string Title { get; set; }

            public string Message { get; set; }

            public string MessageEmail { get; set; }
            public enum NotifyStatus
            {
                Success,
                Warning,
                Danger,
                Info
            }

        }

        public class Mail
        {
            #region MailSender
            public static bool MailSender(string smtp, string from, string to, string subject, string body)
            {
                bool status = false;
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient smtpServer = new SmtpClient(smtp);
                    mail.From = new MailAddress(from);
                    mail.To.Add(to);
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    string htmlbody = body.ToString();
                    mail.Body = htmlbody;
                    smtpServer.Send(mail);

                    return (status = true);
                }
                catch (Exception)
                {
                    return status;
                }
                #endregion


            }
        }

        public static bool IsValidEmail(string ValidEmail)
        {
            Regex reg = new Regex("^((([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])" +
                "+(\\.([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])+)*)|((\\x22)" +
                "((((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(([\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x7f]|\\x21|[\\x23-\\x5b]|[\\x5d-\\x7e]|" +
                "[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(\\\\([\\x01-\\x09\\x0b\\x0c\\x0d-\\x7f]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\u" +
                "FDF0-\\uFFEF]))))*(((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(\\x22)))@((([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|" +
                "(([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|\\d|" +
                "[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.)+(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|[\\u00A0-\\uD7FF\\uF900" +
                "-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFF" +
                "EF])))\\.?$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
            if (!string.IsNullOrEmpty(ValidEmail) && reg.IsMatch(ValidEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public class TextFormat 
        //{
        //    public static string CropText(string text, int maxLength, bool doDots)
        //    {
        //        return (text.Length <= maxLength ? text.Substring(0, maxLength) + (doDots ? "..."));
        //    }

        //}

        public static bool CheckDate(DateTime startdate, DateTime enddate, DateTime startbookingdate, DateTime endbookingdate)
        {
            bool result = true;

            if (startdate >= startbookingdate && startdate <= endbookingdate)
            {
                result = false;
            }
            else if (enddate >= startbookingdate && enddate <= endbookingdate)
            {
                result = false;
            }
            else if (startdate >= startbookingdate && enddate <= endbookingdate)
            {
                result = false;
            }

            return result;
        }

    }
}