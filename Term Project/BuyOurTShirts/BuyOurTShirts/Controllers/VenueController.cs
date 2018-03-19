using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    public class VenueController : Controller
    {
        // GET: Venues
        public IActionResult Venue() => View();
        public IActionResult Venues() => View();


    }
}