using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrossOutCommunity.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CrossOutCommunity.Controllers
{
    public class AdminController : Controller
    {

        private UserManager<Account> userManager;
        private RoleManager<IdentityRole> roleManager;

        public AdminController(UserManager<Account> um, RoleManager<IdentityRole> rm)
        {
            userManager = um;
            roleManager = rm;
        }

        //GETS

        public IActionResult Index() => View();
        public ViewResult AccountView() => View(userManager.Users);
        public ViewResult AccountCreate() => View();
        public ViewResult RoleView() => View(roleManager.Roles);
        public IActionResult RoleCreate() => View();

        //POSTS
        [HttpPost]
        public async Task<IActionResult> AccountCreate(Account model)
        {
            if (ModelState.IsValid)
            {
                Account acct = new Account
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email
                };

                IdentityResult result
                    = await userManager.CreateAsync(acct, model.Password);
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



        [HttpPost]
        public async Task<IActionResult> RoleCreate([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result
                    = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }


        [HttpPost]
        public async Task<IActionResult> RoleDelete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "No role found");
            }
            return View("Index", roleManager.Roles);
        }



        public async Task<IActionResult> EditRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<Account> members = new List<Account>();
            List<Account> nonMembers = new List<Account>();
            foreach (Account acct in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(acct, role.Name)
                ? members : nonMembers;
                list.Add(acct);
            }
            return View(new AccountRole
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(Role model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    Account acct = await userManager.FindByIdAsync(userId);
                    if (acct != null)
                    {
                        result = await userManager.AddToRoleAsync(acct,
                        model.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }

                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    Account acct = await userManager.FindByIdAsync(userId);
                    if (acct != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(acct,
                        model.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return await EditRole(model.RoleId);
            }
        }


        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}