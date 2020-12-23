using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopingCart_Project.ViewModels;

namespace ShopingCart_Project.Controllers
{
  
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
       
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl

            }) ;
        }
        [HttpPost]
        public  async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = await userManager.FindByNameAsync(loginViewModel.UserName);
            if(user !=null)
            {
                var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if(result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    else
                        return RedirectToAction(loginViewModel.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "نام کاربری یا رمز عبور وجود ندارد");
            return View(loginViewModel);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = loginViewModel.UserName,

                };
                var result = await userManager.CreateAsync(user, loginViewModel.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "خطایی رخ داده است";
                    ViewBag.Style = "alert alert-danger";
                }
            }
            return View(loginViewModel);
        }
        [HttpPost]
       
        public  async Task<IActionResult> LogOut()
        {
            if(signInManager.IsSignedIn(User))
            {
             await signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

    }

}
