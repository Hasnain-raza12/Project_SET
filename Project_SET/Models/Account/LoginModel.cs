using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_SET.Models.Account
{
    public class LoginModel
    {
        [Display(Name ="User Name :")]
        [Required(ErrorMessage = "This field is required")]
        public string UserName { get; set; }

        [Display(Name = "Password :")]
        [Required(ErrorMessage ="This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me :")]
        public bool RememberMe { get; set; }
    }
}