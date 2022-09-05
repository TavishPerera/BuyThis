using System.ComponentModel.DataAnnotations;

namespace BuyThis.ViewModels
{
    public class UserViewModel
    {
        //[Required]
        //[MinLength(5)]
        //[Display(Name = "User Name")]
        //public string UserName { get; set; }
        [Required]
        [MinLength(5)]
        [Display(Name = "First Name")]
        public string UserFName { get; set; }
        [Required]
        [MinLength(5)]
        [Display(Name = "Last Name")]
        public string UserLName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Required]
        [MinLength(9)]
        [MaxLength(10)]
        [Display(Name = "Phone Number")]
        public string UserPhoneNumber { get; set; }
        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}
