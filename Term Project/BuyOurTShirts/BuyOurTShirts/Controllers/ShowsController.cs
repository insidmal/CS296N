using Microsoft.AspNetCore.Mvc;

namespace BOTSwebsite.Controllers
{
    public class ShowsController : Controller
    {
        // GET: Shows
        public IActionResult Shows() => View();
        public IActionResult Show() => View();


    }
}