using SportsData.Data;
using SportsData.Models;

namespace SportsData.Services
{
    public class StadiumService
    {
        private readonly SportsDataDbContext context;
        public StadiumService(SportsDataDbContext cont)
        {
            context = cont;
        }

        public bool CheckIfStadiumExists(AddTeamModel model)
        {
            var stad = context.Stadiums.FirstOrDefault(s => s.Name == model.Stadium);
            if (stad == null)
            {
                return false;
            }
            return true;

        }
    }
}
