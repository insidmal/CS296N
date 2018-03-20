using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    public class HomeController : Controller
    {

        private IBlogRepository blogRepo;

        public HomeController(IBlogRepository bR)
        {
            blogRepo = bR;

        }


        public ActionResult Index()
        {
            return View(blogRepo.GetLatestPost() ?? new Blog { ID = 0, title = "", summary = "" });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Booking()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}