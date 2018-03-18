using Microsoft.AspNetCore.Mvc;

namespace BOTSwebsite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}