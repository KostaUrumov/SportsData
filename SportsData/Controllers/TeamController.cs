using Microsoft.AspNetCore.Mvc;
using SportsData.Data;
using SportsData.Data.Enm;
using SportsData.Data.Models;
using SportsData.Models;
using SportsData.Services;

namespace SportsData.Controllers
{
    public class TeamController : Controller
    {
        private readonly SportsDataDbContext context;
        public TeamController()
        {
            context = new SportsDataDbContext();
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(AddTeamModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AddTeam");
            }
            else
            {
                SportName name;   
                bool isGood = Enum.TryParse(model.Name, out name);
                Team team = new Team();
                team.SportName = name;
                team.Name = model.Name;
                team.CoachID = model.Coach;
                team.StadiumID = model.Stadium;
                team.Id = context.Teams.Count() + 1;
                context.Teams.Add(team);
            }

            context.SaveChanges();
            return View();
        }


    }
}
