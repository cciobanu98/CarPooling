using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace CarPooling.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[Display(Name = "Remember?")]
        //public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
