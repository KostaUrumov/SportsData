using Microsoft.AspNetCore.Mvc;

namespace SportsData.Controllers
{
    public class CoachController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewCoach()
        {
            return View();
        }
    }
}
