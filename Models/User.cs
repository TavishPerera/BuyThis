using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyThis.Data
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public int UserNumber { get; set; }
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserRole { get; set; }
        public string UserPassword { get; set; }
    }
}
