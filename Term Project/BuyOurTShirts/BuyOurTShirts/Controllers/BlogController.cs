using Microsoft.AspNetCore.Mvc;

namespace BOTSwebsite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public IActionResult Index() => Index();
        public IActionResult Post() => View();

    }
}