using Microsoft.AspNetCore.Mvc;

namespace BOTSwebsite.Controllers
{
    public class VenueController : Controller
    {
        // GET: Venues
        public IActionResult Venue() => View();
        public IActionResult Venues() => View();


    }
}