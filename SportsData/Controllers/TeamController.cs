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

        public IActionResult TeamIsAlreadyIn()
        {
            ViewBag.Message = "Team Is already listed";
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(AddTeamModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddTeam");
            }

            
            SportName name;
            bool isGood = Enum.TryParse(model.SportName, out name);
            if (isGood == false)
            {
                return RedirectToAction("AddTeam");
            }
            var teamIsThere = context.Teams.FirstOrDefault(t => t.Name == model.Name && t.SportName == name);

            if (teamIsThere != null)
            {

                return RedirectToAction("TeamIsAlreadyIn");
            }

            var team = new Team();
            team.SportName = name;
            team.Name = model.Name;
            team.CoachID = model.Coach;
            team.StadiumID = model.Stadium;

            context.Teams.Add(team);

            context.SaveChangesAsync();
            return RedirectToAction("AllTeams");
        }

        public IActionResult AllTeams()
        {
            List<Team> list = context.Teams.ToList();
            if (list == null)
            {
                RedirectToAction("AddTeam");
            }
            foreach (var mar in list)
            {
                mar.Coach = context.Coaches.FirstOrDefault(c => c.Id == mar.CoachID);
                mar.Stadium = context.Stadiums.FirstOrDefault(s => s.Id == mar.StadiumID);
            }
            return View(list);

        }


    }
}
