using Microsoft.AspNetCore.Mvc;
using SportsData.Data;
using SportsData.Data.Models;
using SportsData.Models;
using SportsData.Services;
using System.Linq;

namespace SportsData.Controllers
{
    public class CoachController : Controller
    {
        private SportsDataDbContext context;
        private CoachService coachService;
        public CoachController(SportsDataDbContext _context, CoachService _service)
        {
            context = _context;
            coachService = _service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewCoach()
        {
            return View();
        }

        public IActionResult CoachIsAlreadyIn()
        {
            ViewBag.Message = "Coach Is already Listed";
            return View();
        }

        [HttpPost]
        public IActionResult AddCoach(AddCoachModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Invalid required data";
                return RedirectToAction("NewCoach");
            }

            if (coachService.CheckCoachIsIn(model) != false)
            {

                return RedirectToAction("CoachIsAlreadyIn");
            }

            else
            {
                coachService.AddModelToDb(model);

                return RedirectToAction("AllCoaches");
            }
        }

        public IActionResult AllCoaches()
        {
            List<Coach> list = context.Coaches.ToList();

            return View(list);
        }

        public IActionResult CoachesWithoutTeam()
        {
            var freeCoaches = context.Coaches
                .Where(c => c.isHired == false)
                .OrderByDescending(c => c.FirstName)
                .ThenByDescending(c => c.LastName)
                .ToList();

            return View(freeCoaches);
        }

        public IActionResult HiredCoaches()
        {
            var hired = context.Coaches
                .Where(c => c.isHired == true)
                .OrderByDescending(c => c.FirstName)
                .ThenByDescending(c => c.LastName)
                .ToList();

            return View(hired);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(AddCoachModel model, int id)
        {
            coachService.Edit(model, id);
            return RedirectToAction("AllCoaches");
        }

        public IActionResult Delete(int id)
        {
            if (coachService.Delete(id) == "can`t delete")
            {
                ViewBag.message = "Coach can`t be deleted. He has a team.";
                return View();
            }

            return RedirectToAction("AllCoaches");
        }

        public IActionResult OrderByName()
        {
            List<Coach> list = context.Coaches
                .OrderBy(x=>x.FirstName)
                .ThenBy(x=>x.LastName)
                .ToList();

            return View(list);
        }

        public IActionResult OrderByAge()
        {
            List<Coach> list = context.Coaches
                .OrderBy(x => x.Age)
                .ToList();

            return View(list);
        }
    }
}
