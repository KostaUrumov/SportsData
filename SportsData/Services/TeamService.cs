using SportsData.Data.Models;
using SportsData.Data;
using SportsData.Models;
using SportsData.Data.Enm;

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
           return list;
        }

    }
}
