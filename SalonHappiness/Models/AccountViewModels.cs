using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalonHappiness.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Det {0} skal være mindst {2} tegn lange.", MinimumLength = 2)]
        [Display(Name = "Brugernavn")]
        public string Fname { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Kode")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Husker du denne browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string Password { get; set; }

        [Display(Name = "Husk mig?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Indtast gyldig email adresse")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Indsat dit fulde navn")]
        [StringLength(50, ErrorMessage = "Det {0} skal være mindst {2} tegn lange.", MinimumLength = 2)]
        [Display(Name = "Brugernavn")]
        public string Fname { get; set; }

        [CheckBoxRequired(ErrorMessage = "Du mangler at acceptere betingelserne")]
        [Display(Name = "Jeg accepterer betingelser")]
        public bool Accepted { get; set; }

        [Required(ErrorMessage = "Indsat en adgangskode")]
        [StringLength(100, ErrorMessage = "Det {0} skal være mindst {2} tegn lange.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekræfte Adgangskode")]
        [Compare("Password", ErrorMessage = "Adgangskoden og bekræftelsesadgangskoden stemmer ikke overens.")]
        public string ConfirmPassword { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Det {0} skal være mindst {2} tegn lange.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekræfte Adgangskode")]
        [Compare("ConfirmPassword", ErrorMessage = "Adgangskoden og bekræftelsesadgangskoden stemmer ikke overens.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
