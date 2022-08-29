using System.ComponentModel.DataAnnotations;

namespace BuyThis.ViewModels
{
    public class LoginViewModel 
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
