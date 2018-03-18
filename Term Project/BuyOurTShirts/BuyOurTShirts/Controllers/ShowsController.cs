using Microsoft.AspNetCore.Mvc;

namespace BOTSwebsite.Controllers
{
    public class ShowsController : Controller
    {
        // GET: Shows
        public ActionResult Index()
        {
            return View();
        }
    }
}