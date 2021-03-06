﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossOutCommunity.Models;
using CrossOutCommunity.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CrossOutCommunity.Controllers
{
    public class ContactController : Controller
    {
        private IMessageRepository messageRepo;

        public ContactController(IMessageRepository repo)
        {
            messageRepo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact(Contact c)
        {
            ViewData["Message"] = "Contact Us";

            return View(c);
        }

        public ViewResult ViewContact()
        {
            
            return View(messageRepo.GetAllMessages());
        }
    }
}