using Microsoft.AspNetCore.Mvc;
using SportsData.Data;
using SportsData.Data.Enm;
using SportsData.Data.Models;
using SportsData.Models;

namespace SportsData.Controllers
{
    public class StadiumController : Controller
    {
        private SportsDataDbContext context;
        public StadiumController(SportsDataDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddStadium ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStadium(AddStadiumModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddStadium");
            }
            else
            {
                
                var stad = new Stadium();
                stad.Capacity = model.Capacity;
                stad.Name = model.StadiumName;
                context.Stadiums.AddRange(stad);
                context.SaveChanges();
                
            }
            return View();
        }
    }
}
