using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrossOutCommunity.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ImportantLocations()
        {
            return View();
        }
        public IActionResult SignificantPeople()
        {
            return View();
        }
    }
}