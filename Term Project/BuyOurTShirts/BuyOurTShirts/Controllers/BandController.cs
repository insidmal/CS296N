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

        public IActionResult VenueEdit(int id) => View(venueRepo.GetVenueById(id));
        [HttpGet]
        public IActionResult VenueCreate() => View();
        [HttpPost]
        public IActionResult VenueCreate(Venue venue)
        {
            venueRepo.Add(venue);           
            return View("VenueList");
        }

        [HttpPost]
        public IActionResult VenueEdit(Venue venue)
        {
            venueRepo.Edit(venue);
            return View("VenueEdit",venue.ID);
        }


        [HttpPost]
        public IActionResult VenueDelete(Venue venue)
        {
            venueRepo.Delete(venue.ID);
            return View("VenueList");
        }

        #endregion

    }
}