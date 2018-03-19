using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    public class ShowsController : Controller
    {
        // GET: Shows
        public IActionResult Shows() => View();
        public IActionResult Show() => View();


    }
}