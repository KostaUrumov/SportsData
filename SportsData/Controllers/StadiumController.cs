using Microsoft.AspNetCore.Mvc;
using SportsData.Data;
using SportsData.Data.Enm;
using SportsData.Data.Models;
using SportsData.Models;
using SportsData.Services;
using System.Collections.Generic;

namespace SportsData.Controllers
{
    public class StadiumController : Controller
    {
        private SportsDataDbContext context;
        private StadiumService stadiumService;
        public StadiumController(SportsDataDbContext _context, StadiumService _service)
        {
            context = _context;
            stadiumService = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddStadium()
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

            if (stadiumService.StadiumIsIn(model.StadiumName) == true)
            {

                return RedirectToAction("StadiumIsAlreadyIn");
            }
            stadiumService.AddStadium(model);

            return RedirectToAction("AllStadiums");
        }

        public IActionResult AllStadiums()
        {
            List<Stadium> list = context.Stadiums
                .OrderByDescending(x=>x.Name)
                .ToList();

            return View(list);
        }

        public IActionResult StadiumIsAlreadyIn()
        {
            ViewBag.Message = "Stadium Is already Listed";
            return View();
        }

        public IActionResult Delete(int Id)
        {
            if (stadiumService.Delete(Id) == false)
            {
                ViewBag.message = "Stadium can`t be deleted. It has a home team";
                return View();
            }
            return RedirectToAction("AllStadiums");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(AddStadiumModel model, int Id)
        {
            
            if (stadiumService.Edit(model, Id) == false)
            {
                return RedirectToAction("AllStadiums");
            }
            return RedirectToAction("AllStadiums");
        }

        public IActionResult OrderByCapacity()
        {
            List<Stadium> list = context.Stadiums
                .OrderByDescending(x=>x.Capacity)
                .ToList();
            return View(list);
        }

        public IActionResult Alphabetically()
        {
            List<Stadium> list = context.Stadiums
               .OrderBy(x => x.Name)
               .ToList();
            
            return View(list);
        }

        public IActionResult Alphabeticallyv2()
        {
            List<Stadium> list = context.Stadiums
               .OrderByDescending(x => x.Name)
               .ToList();

            return View(list);

        }

        public IActionResult OrderByCapacityv2()
        {
            List<Stadium> list = context.Stadiums
                .OrderBy(x => x.Capacity)
                .ToList();
            return View(list);

        }



    }
}
