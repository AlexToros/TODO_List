using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestExersize.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль!")]
        public string Password { get; set; }
    }
}