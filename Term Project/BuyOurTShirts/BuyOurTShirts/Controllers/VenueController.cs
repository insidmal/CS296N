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

        // GET: Shows
        public IActionResult Index() => View(venueRepo.GetAllVenues());
        public IActionResult Show(int id) => View(venueRepo.GetVenueById(id));

    }
}