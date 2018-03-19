using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media
        public IActionResult Pictures() => View();
        public IActionResult Picture() => View();

        public IActionResult Videos() => View();
        public IActionResult Video() => View();
        public IActionResult Songs() => View();
        public IActionResult Song() => View();



    }
}