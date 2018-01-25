using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossOutCommunity.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrossOutCommunity.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
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
            Quiz qA = new Quiz();
            if (q.Answer!=null && (q.Answer == qA.Answers[q.QuestionNum]))
            {
                q.NumCorrect++;
                q.LastCorrect = true;
            }
            q.QuestionNum++;
            return View("Quiz",q);
        }
    }
}