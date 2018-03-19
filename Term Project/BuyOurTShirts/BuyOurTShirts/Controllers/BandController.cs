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
        [HttpPost]
        public IActionResult Create(Venue venue)
        {
   
         
            

            return View("VenueList");
        }
        #endregion

    }
}