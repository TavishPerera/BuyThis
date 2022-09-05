using System.ComponentModel.DataAnnotations;

namespace BuyThis.ViewModels
{
    public class LoginViewModel 
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
