using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BOTSwebsite.Controllers
{
    public class BandController : Controller
    {
        // GET: Band

        private IVenueRepository venueRepo;
        public BandController(IVenueRepository vR) => venueRepo = vR;

        #region Media
        public IActionResult MediaCreate() => View();
        public IActionResult MediaEdit() => View();
        #endregion

        #region Shows
        #endregion

        #region Venue
        public IActionResult VenueList() => View(venueRepo.GetAllVenues());
        
        public IActionResult VenueEdit(int id) => View(venueRepo.GetVenueById(id));
        [HttpGet]
        public IActionResult VenueCreate() => View();
        [HttpPost]
        public IActionResult VenueCreate(Venue venue)
        {
            venueRepo.Add(venue);
            ViewData["Message"] = "Venue Added!";
            return View("VenueList", venueRepo.GetAllVenues());
        }

        [HttpPost]
        public IActionResult VenueEdit(Venue venue)
        {
            venueRepo.Edit(venue);
            ViewData["Message"] = "Venue Updated!";
            return View("VenueEdit",venue);
        }


        [HttpPost]
        public IActionResult VenueDelete(Venue venue)
        {
            venueRepo.Delete(venue.ID);
            ViewData["Message"] = "Venue Deleted";
            return View("VenueList", venueRepo.GetAllVenues());
        }

        #endregion

    }
}