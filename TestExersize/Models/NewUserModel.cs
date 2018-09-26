using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestExersize.Models
{
    public class NewUserModel
    {
        [Required(ErrorMessage = "Необходимо ввести имя.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо ввести Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Необходимо ввести пароль.")]
        public string Password { get; set; }
    }
}