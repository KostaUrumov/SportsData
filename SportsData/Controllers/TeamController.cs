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
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddTeam");
            }
            else
            {
                SportName name;
                bool isGood = Enum.TryParse(model.Name, out name);
                var team = new Team();
                team.SportName = name;
                team.Name = model.Name;
                team.CoachID = model.Coach;
                team.StadiumID = model.Stadium;

                context.Teams.Add(team);
            }


            await context.SaveChangesAsync();
            return View();
        }

        public IActionResult AllTeams()
        {
            List<Team> list = context.Teams.ToList();
            foreach (var mar in list)
            {
                mar.Coach = context.Coaches.FirstOrDefault(c => c.Id == mar.CoachID);
                mar.Stadium = context.Stadiums.FirstOrDefault(s => s.Id == mar.StadiumID);

<<<<<<< HEAD
            }
            if (list == null)
            {
                RedirectToAction("AddTeam");
            }
=======


>>>>>>> cc1ffaf96913be9c35fb55b2e21ba5505fc0a308
            return View(list);

        }


    }
}
