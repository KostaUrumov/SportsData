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
        private readonly TeamService teamService;
        private readonly CoachService coach;
        public TeamController(TeamService _teamService, SportsDataDbContext _cont, CoachService _coach)
        {
            context = _cont;
            teamService = _teamService;
            coach = _coach;
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
            var coh = context.Coaches.FirstOrDefault(c => c.Id == model.Coach);

            if (teamIsThere != null)
            {

                return RedirectToAction("TeamIsAlreadyIn");
            }

            teamService.AddModelToDb(model);

            coach.HireCoach(coh);


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
