﻿using System.ComponentModel.DataAnnotations;

namespace BuyThis.ViewModels
{
    public class LoginViewModel 
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
