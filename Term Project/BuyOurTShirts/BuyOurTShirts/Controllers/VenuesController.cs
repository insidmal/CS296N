using Microsoft.AspNetCore.Mvc;

namespace BOTSwebsite.Controllers
{
    public class VenuesController : Controller
    {
        // GET: Venues
        public ActionResult Index()
        {
            return View();
        }
    }
}