using Microsoft.AspNetCore.Mvc;

namespace BOTSwebsite.Controllers
{
    public class BandController : Controller
    {
        // GET: Band
        public IActionResult ContentCreate() => View();
        public IActionResult ContentEdit() => View();
        public IActionResult MediaCreate() => View();
        public IActionResult MediaEdit() => View();



    }
}