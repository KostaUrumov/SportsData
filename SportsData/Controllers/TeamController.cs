using Microsoft.AspNetCore.Mvc;

namespace SportsData.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }


    }
}
