using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestExersize.Infrastructure;
using TestExersize.Models;

namespace TestExersize.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {
            AppUser user = await UserManager.FindAsync(details.Name, details.Password);

            if (user == null)
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            else {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);
                return RedirectToAction("Index","Home");
            }
            return View(details);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(NewUserModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser { UserName = model.Name, Email = model.Email};
                IdentityResult result = await UserManager.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Login");
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        private IAuthenticationManager AuthManager { get => HttpContext.GetOwinContext().Authentication; }

        private AppUserManager UserManager { get => HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
    }
}