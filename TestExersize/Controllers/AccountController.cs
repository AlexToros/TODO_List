﻿using Microsoft.AspNet.Identity;
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
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(details.Email, details.Password);

                if (user == null)
                    ModelState.AddModelError("", "Некорректное имя или пароль.");
                else
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View(details);
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Create(NewUserModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser { FirstName = model.Name, Email = model.Email, UserName = model.Email };
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
        
        [AllowAnonymous]
        public ActionResult Exit(string F)
        {
            AuthManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        private IAuthenticationManager AuthManager { get => HttpContext.GetOwinContext().Authentication; }

        private AppUserManager UserManager { get => HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
    }
}