using Microsoft.AspNetCore.Mvc;

namespace SportsData.Controllers
{
    public class StadiumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddStadium()
        {
            return View();
        }
    }
}
