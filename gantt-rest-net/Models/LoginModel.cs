using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gantt_rest_net.Models
{
    public class LoginModel:Inheritance
    {
        
            [Required(ErrorMessage = "Please enter an email address.")]
            [Display(Name = "E-Mail")]
            public string EMail { get; set; }

            [Required(ErrorMessage = "Please enter a password.")]
            [DataType(DataType.Password)]
            [Display(Name = "Şifre")]
            public string Password { get; set; }
        
    }
}