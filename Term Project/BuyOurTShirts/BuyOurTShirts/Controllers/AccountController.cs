using BuyOurTShirts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuyOurTShirts.Controllers
{

    public class AccountController : Controller
    {
        private UserManager<Account> userManager;
        private SignInManager<Account> signInManager;
        public AccountController(UserManager<Account> userMgr, SignInManager<Account> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }


        // GET: Account
        
        public ActionResult CommentAdd() => View();
        public ActionResult CommentEdit() => View();
        
        public ActionResult Create() => View();
        public ActionResult Delete() => View();


        public async Task<ActionResult> Index()
        {
            var current = await GetCurrentUserAsync();
            if (current != null) return View(current);
            else return View("Login");
        }

        public async Task<ActionResult> Edit()
        {
            var current = await GetCurrentUserAsync();
            if (current != null) return View(current);
            else return View("Login");
          }


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


        [HttpPost]
        public async Task<IActionResult> Create(Account model)
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
                    ViewData["Message"] = "Account Created!";
                    await signInManager.SignInAsync(acct,false);
                    return View("Index",acct);
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
        public async Task<IActionResult> Edit(Account acct)
        {

            var current = GetCurrentUserAsync();
            if (current.Result.Id == acct.Id)
            {
                Account updAcct = await userManager.FindByIdAsync(acct.Id);

                updAcct.FirstName = acct.FirstName;
                updAcct.LastName = acct.LastName;
                updAcct.Email = acct.Email;
                updAcct.Bio = acct.Bio;
                updAcct.UserName = acct.UserName;
                if (acct.Password != null) updAcct.Password = acct.Password;

                await userManager.UpdateAsync(updAcct);

                ViewData["Message"] = "Account Updated!";
            }
            return View("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var current = GetCurrentUserAsync();
            if (current.Result.Id == id)
            {

                Account acct = await userManager.FindByIdAsync(id);
                if (acct != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(acct);
                    if (result.Succeeded)
                    {
                        ViewData["Message"] = "Account Deleted";

                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No Account found");
                }
                
            }
            return RedirectToAction("Index", "Home");
        }

        //account methods 
        public Task<Account> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}