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
        public StadiumController()
        {
            context = new SportsDataDbContext();
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
        public async Task<IActionResult> AddStadium(AddStadiumModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddStadium");
            }
            else
            {
                
                Stadium stad = new Stadium();
                stad.Capacity = model.Capacity;
                stad.Id = 1;
                stad.Name = model.StadiumName;
                context.Stadiums.Add(stad);
                
            }

            await context.SaveChangesAsync();
            return View();
        }
    }
}
