using SportsData.Data.Models;
using SportsData.Data;
using SportsData.Models;
using SportsData.Data.Enm;

namespace SportsData.Services
{
    public class TeamService
    {
        private readonly SportsDataDbContext context;
        public TeamService(SportsDataDbContext cont)
        {
            context = cont;
        }

        public void AddModelToDb(AddTeamModel model)
        {
            SportName name;
            bool isGood = Enum.TryParse(model.SportName, out name);
            var team = new Team();
            team.SportName = name;
            team.Name = model.Name;
            team.CoachID = model.Coach;
            team.StadiumID = model.Stadium;
            

            context.Teams.AddRange(team);
            context.SaveChanges();
        }

        public void ReplaceModel(int id, AddTeamModel model)
        {
            
            var findTeam = context.Teams.First(x => x.Id == id);
            var coh = context.Coaches.FirstOrDefault(c => c.Id == model.Coach);
            var stad = context.Stadiums.First(s => s.Id == model.Stadium);
            findTeam.Name = model.Name;
            findTeam.Coach = coh;
            findTeam.Stadium = stad;
            context.SaveChanges();
        }
    }
}
