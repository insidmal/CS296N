using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    public class VenueController : Controller
    {

        private IVenueRepository venueRepo;
        private IShowRepository showRepo;
        public VenueController(IVenueRepository vR, IShowRepository sR)
        {
            venueRepo = vR;
            showRepo = sR;
        }

        public IActionResult Index() => View(venueRepo.GetAllVenues());
        public IActionResult Venue(int id)
        {
            Venue v = venueRepo.GetVenueById(id);
            v.Shows = showRepo.GetShowsByVenue(v.ID);
            return View(v);
        }
    }
}