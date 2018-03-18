using Microsoft.AspNetCore.Mvc;

namespace BOTSwebsite.Controllers
{
    public class BandController : Controller
    {
        // GET: Band
        public ActionResult Index()
        {
            return View();
        }
    }
}