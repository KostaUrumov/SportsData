using Microsoft.AspNetCore.Mvc;
using SportsData.Controllers;
using SportsData.Data;
using SportsData.Data.Models;
using SportsData.Models;

namespace SportsData.Services
{
    public class CoachService
    {
        private readonly SportsDataDbContext context;
        public CoachService(SportsDataDbContext cont)
        {
            context = cont;
        }

        public void AddModelToDb(AddCoachModel model)
        {
            var coach = new Coach();
            coach.FirstName = model.FirtsName;
            coach.LastName = model.LastName;
            coach.Age = model.Age;
            context.Coaches.AddRange(coach);
            context.SaveChanges();
        }

    }
}
