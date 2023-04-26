using SportsData.Data.Models;
using SportsData.Data;
using SportsData.Models;
using SportsData.Data.Enm;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;

namespace SportsData.Services
{
    public class TeamService
    {
        private readonly SportsDataDbContext context;
        private readonly CoachService coach;
        public TeamService(SportsDataDbContext cont, CoachService _coach)
        {
            context = cont;
            coach = _coach;
        }

        public void AddModelToDb(AddTeamModel model)
        {
            SportName name;
            bool isGood = Enum.TryParse(model.SportName, out name);
            Stadium stad = context.Stadiums.First(s => s.Name == model.Stadium);
            Coach coh = context.Coaches.First(c => c.FirstName + " " + c.LastName == model.Coach);
            var team = new Team();
            team.SportName = name;
            team.Name = model.Name;
            team.Coach = coh;
            team.Stadium = stad;

            coach.HireCoach(coh);

            context.Teams.AddRange(team);
            context.SaveChanges();
        }

        public void ReplaceModel(int id, AddTeamModel model)
        {

            var findTeam = context.Teams.First(x => x.Id == id);
            var coh = context.Coaches.FirstOrDefault(c => c.FirstName+" "+c.LastName == model.Coach);
            var stad = context.Stadiums.First(s => s.Name == model.Stadium);
            findTeam.Name = model.Name;
            findTeam.Coach = coh;
            findTeam.Stadium = stad;
            context.SaveChanges();
        }

        public bool CheckTeamIsAlreadyIn(AddTeamModel model)
        {
            SportName name;
            bool isGood = Enum.TryParse(model.SportName, out name);
            var teamIsThere = context.Teams.FirstOrDefault(t => t.Name == model.Name && t.SportName == name);
            if (teamIsThere == null)
            {
                return false;
            }
            return true;
        }

        public bool TypeSportCorrectness(AddTeamModel model)
        {
            SportName name;
            bool isGood = Enum.TryParse(model.SportName, out name);
            if (isGood == false)
            {
                return false;
            }
            return true;

        }

        public List<Team> AllTeams()
        {
           List<Team> list = context.Teams.ToList();
            foreach (var mar in list)
            {
                mar.Coach = context.Coaches.First(c => c.Id == mar.CoachID);
                mar.Stadium = context.Stadiums.First(s => s.Id == mar.StadiumID);
            }
           return list;
        }

        public void Delete(int id)
        {
            var findTeam = context.Teams.FirstOrDefault(x => x.Id == id);
            var coach = context.Coaches.First(c => c.Id == findTeam.CoachID);
            coach.isHired = false;
            context.Teams.Remove(findTeam);
            context.SaveChanges();

        }

        public void Edit(AddTeamModel model, int id)
        {
            var teamIsThere = context.Teams.FirstOrDefault(t => t.Id == id);
            var coh = context.Coaches.FirstOrDefault(c => c.FirstName + " " + c.LastName == model.Coach);
            var stad = context.Stadiums.First(s => s.Name == model.Stadium);

            teamIsThere.Name = model.Name;
            teamIsThere.Stadium = stad;
            teamIsThere.Coach = coh;
            coach.HireCoach(coh);
            context.SaveChanges();
        }
        
        public void ChangeCoach(AddCoachModel trainer, int id)
        {
            var team = context.Teams.FirstOrDefault(x => x.Id == id);
            var coa = context.Coaches.First(c => c.Id == team.CoachID);
            coach.Fire(coa);
            var newCoach = context.Coaches.First(c => c.FirstName == trainer.FirtsName && c.LastName == trainer.LastName);
            if (coach.CheckCoachIsHired(newCoach.FirstName+" "+newCoach.LastName) == false)
            {
                team.Coach = newCoach;
                coach.HireCoach(newCoach);
            }
            context.SaveChanges();
            
        }
    }
}
