using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    public class MediaController : Controller
    {

        private IMediaRepository mediaRepo;

        public MediaController(IMediaRepository mR)
        {
            mediaRepo = mR;

        }

        // GET: Media
        public IActionResult Pictures() => View(mediaRepo.GetAllMediaByType(Models.MediaType.Image));
        public IActionResult Item(int id) => View(mediaRepo.GetMediaById(id));
        public IActionResult Videos() => View(mediaRepo.GetAllMediaByType(Models.MediaType.Video));
        public IActionResult Songs() => View(mediaRepo.GetAllMediaByType(Models.MediaType.Audio));

    }
}