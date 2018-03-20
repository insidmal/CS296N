using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    public class ShowController : Controller
    {


        private IShowRepository showRepo;
        

        public ShowController(IShowRepository sR) => showRepo = sR;
        

        // GET: Shows
        public IActionResult Index() => View(showRepo.GetAllShows());
        public IActionResult Show(int id) => View(showRepo.GetShowById(id));



    }
}