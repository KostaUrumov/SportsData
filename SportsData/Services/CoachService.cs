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

        public void HireCoach(Coach coach)
        {
            coach.isHired = true;
            context.SaveChanges();
        }

        public void Fire(Coach coach)
        {
            coach.isHired = false;
            context.SaveChanges();
        }

        public bool CheckCoachIsHired(string name)
        {
            var findCoach = context.Coaches.FirstOrDefault(c => c.FirstName + " " + c.LastName == name);
            if (findCoach.isHired == true || findCoach == null)
            {
                return true;
            }

            return false;

        }

        public bool CheckCoachIsIn(AddCoachModel model)
        {
            var coachIsIn = context.Coaches.FirstOrDefault(t => t.FirstName == model.FirtsName && t.LastName == model.LastName && t.Age == model.Age);
            if (coachIsIn == null)
            {
                return false;
            }
            return true;
        }

        public void Edit(AddCoachModel model, int id)
        {
            var findCoach = context.Coaches.First(x => x.Id == id);
            findCoach.FirstName = model.FirtsName;
            findCoach.LastName = model.LastName;
            findCoach.Age = model.Age;
        }

        public string Delete(int id)
        {
            var coach = context.Coaches.First(s => s.Id == id);
            if (coach.isHired == true)
            {
                
                return "can`t delete";
            }
            context.Coaches.Remove(coach);
            context.SaveChanges();
            return "delete";

        }

    }
}
