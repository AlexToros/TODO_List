using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestExersize.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
    }
}