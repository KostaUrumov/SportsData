using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private readonly StadiumService stadium;
        public TeamController(TeamService _teamService, SportsDataDbContext _cont, CoachService _coach, StadiumService _stadium)
        {
            context = _cont;
            teamService = _teamService;
            coach = _coach;
            stadium = _stadium;
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
        public IActionResult AddTeam(AddTeamModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddTeam");
            }

            if (teamService.TypeSportCorrectness(model) == false)
            {
                return RedirectToAction("AddTeam");
            }

            if (coach.CheckCoachIsHired(model.Coach) == true)
            {
                return RedirectToAction("NoSuchCoach");
            }

            if (stadium.StadiumIsIn(model.Stadium) == false)
            {
                return RedirectToAction("NoSuchStadium");
            }


            if (teamService.CheckTeamIsAlreadyIn(model) == false)
            {
                teamService.AddModelToDb(model);
            }

            else
            {
                return RedirectToAction("TeamIsAlreadyIn");
            }

            return RedirectToAction("AllTeams");
        }


        public IActionResult TeamIsAlreadyIn()
        {
            ViewBag.Message = "Team Is already listed";
            return View();
        }


        public IActionResult NoSuchCoach()
        {
            ViewBag.Message = "Coach is not available to be assigned";
            return View();
        }

        public IActionResult NoSuchStadium()
        {
            
            ViewBag.Message = "Stadium is not available";
            return View();
        }
        
        public IActionResult AllTeams()
        {
            if (teamService.AllTeams() == null)
            {
                RedirectToAction("AddTeam");
            }
            
            return View(teamService.AllTeams());
        }

        public IActionResult Delete(int id)
        {
            teamService.Delete(id);
            return RedirectToAction("AllTeams");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(AddTeamModel model, int id)
        {
            teamService.Edit(model, id);
            return RedirectToAction("AllTeams");
        }

        [HttpGet]
        public IActionResult ChangeCoach()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ChangeCoach(AddCoachModel coach, int id)
        {
            teamService.ChangeCoach(coach, id);
            return RedirectToAction("AllTeams");
        }
    }
}
