using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossOutCommunity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrossOutCommunity.Controllers
{
        [Authorize]
        public class AccountController : Controller
        {
            private UserManager<Account> userManager;
            private SignInManager<Account> signInManager;

            public AccountController(UserManager<Account> userMgr, SignInManager<Account> signinMgr)
            {
                userManager = userMgr;
                signInManager = signinMgr;
            }

        public IActionResult AccessDenied() => View();

        [AllowAnonymous]
            public IActionResult Login(string returnUrl)
            {
                ViewBag.returnUrl = returnUrl;
                return View();
            }

            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(Login model, string returnUrl)
            {
                if (ModelState.IsValid)
                {

                    Account acct = await userManager.FindByEmailAsync(model.Email);

                    if (acct != null)
                    {
                        await signInManager.SignOutAsync();
                        var result = await signInManager.PasswordSignInAsync(
                                acct, model.Password, false, false);
                        if (result.Succeeded)
                        {
                            return Redirect(returnUrl ?? "/");
                        }
                    }

                    ModelState.AddModelError(nameof(model.Email),
                    "Invalid user or password");
                }
                return View(model);
            }

            [Authorize]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
        }
    }