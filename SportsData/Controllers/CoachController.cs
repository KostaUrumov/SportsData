using Microsoft.AspNetCore.Mvc;
using SportsData.Data;
using SportsData.Data.Models;
using SportsData.Models;

namespace SportsData.Controllers
{
    public class CoachController : Controller
    {
        private SportsDataDbContext context;
        public CoachController(SportsDataDbContext _context)
        {
            context = _context;
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

        [HttpPost]
        public async Task<IActionResult> AddCoach(AddCoachModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddStadium");
            }
            else
            {

                var coach = new Coach();
                coach.FirstName = model.FirtsName;
                coach.LastName = model.LastName;
                coach.Age = model.Age;
                context.Coaches.AddRange(coach);

            }
            await context.SaveChangesAsync();
            return RedirectToAction("AllCoaches");
        }

        public  IActionResult AllCoaches()
        {
            List<Coach> list = context.Coaches.ToList();

            return View(list);
        }
    }
}
