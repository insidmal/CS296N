using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    public class ShowsController : Controller
    {


        private IVenueRepository venueRepo;
        private IShowRepository showRepo;



        public ShowsController(IVenueRepository vR, IShowRepository sR)
        {
            venueRepo = vR;
            showRepo = sR;
        }

        // GET: Shows
        public IActionResult Index() => View(showRepo.GetAllShows());
        public IActionResult Show(int id) => View(showRepo.GetShowById(id));


    }
}