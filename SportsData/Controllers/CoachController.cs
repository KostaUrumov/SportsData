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
        private CoachService service;
        public CoachController(SportsDataDbContext _context, CoachService _service)
        {
            context = _context;
            service = _service;
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
            return View ();
        }

        [HttpPost]
        public IActionResult AddCoach(AddCoachModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddCoach");
            }

            var coachIsIn = context.Coaches.FirstOrDefault(t => t.FirstName == model.FirtsName && t.LastName == model.LastName && t.Age == model.Age);

            if (coachIsIn != null)
            {

                return RedirectToAction("CoachIsAlreadyIn");
            }

            else
            {
                service.AddModelToDb(model);

                return RedirectToAction("AllCoaches");
            }
        }

        public  IActionResult AllCoaches()
        {
            List<Coach> list = context.Coaches.ToList();

            return View(list);
        }
    }
}
