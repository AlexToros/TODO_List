using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestExersize.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc;

namespace TestExersize.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        private AppUserManager UserManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        }
    }
}