using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrossOutCommunity.Models;
using Microsoft.AspNetCore.Identity;

namespace CrossOutCommunity.Controllers
{
    public class AdminController : Controller
    {

        private UserManager<Account> userManager;

        public AdminController(UserManager<Account> um)
        {
            userManager = um;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult ViewUser() => View(userManager.Users);
        [HttpGet]
        public ViewResult CreateUser() => View();


        [HttpPost]
        public async Task<IActionResult> CreateUser(Account model)
        {
            if (ModelState.IsValid)
            {
                Account user = new Account
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email
                };

                IdentityResult result
                    = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }


    }
}