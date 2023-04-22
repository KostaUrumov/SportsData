﻿using Microsoft.AspNetCore.Mvc;
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
                ViewBag.message = "Invalid required data";
                return RedirectToAction("NewCoach");
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

        public IActionResult AllCoaches()
        {
            List<Coach> list = context.Coaches.ToList();

            return View(list);
        }

        public IActionResult CoachesWithoutTeam()
        {
            var freeCoaches = context.Coaches
                .Where(c => c.isHired == false)
                .OrderByDescending(c=>c.FirstName)
                .ThenByDescending(c=>c.LastName)
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
            var findCoach = context.Coaches.First(x => x.Id == id);
            findCoach.FirstName = model.FirtsName;
            findCoach.LastName = model.LastName;
            findCoach.Age = model.Age;
            return RedirectToAction("AllCoaches");
        }


    }
}
