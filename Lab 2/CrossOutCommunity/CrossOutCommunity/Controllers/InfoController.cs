using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossOutCommunity.Models;
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

        public IActionResult Quiz(Quiz q)
        {
            q = new Quiz();
            return View(q);
        }

        [HttpPost]
        public IActionResult CheckQuiz(Quiz q)
        {
            Quiz qA = new Models.Quiz();
            string ans = "";

            for (int i = 0; i < 5; i++)
            {
                ans = "";
                if (i == 0) ans = q.q1;
                else if (i == 1) ans = q.q2;
                else if (i == 2) ans = q.q3;
                else if (i == 3) ans = q.q4;
                else if (i == 4) ans = q.q5;
                if (ans == qA.Answers[0]) q.AnsCheck[0] = "Correct!";
                else q.AnsCheck[0] = "Incorrect";
                
            }
            return View(q);
        }
    }
}