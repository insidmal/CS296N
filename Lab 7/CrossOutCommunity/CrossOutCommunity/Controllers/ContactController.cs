using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossOutCommunity.Models;
using CrossOutCommunity.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossOutCommunity.Controllers
{
    public class ContactController : Controller
    {
        private IUserRepository userRepo;

        public ContactController(IUserRepository repo)
        {
            userRepo = repo;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Contact(Contact c)
        {
            ViewData["Message"] = "Contact Us";

            return View(c);
        }

        [Authorize]
        [HttpPost]
        public RedirectToActionResult Contact(string name, string email, string message)
        {

            User use = new User { Name = name, EmailAddress = email };
            if (message != null)
            {
                Message mess = new Message { ContactMessage = message, UserID = use.UserID };
                use.Messages.Add(mess);
                userRepo.AddUser(use);
            }


            return RedirectToAction("ViewContact");
        }

        [Authorize(Roles = "member")]
        public ViewResult ViewContact()
        {
            
            return View(userRepo.GetAllUsers());
        }
    }
}