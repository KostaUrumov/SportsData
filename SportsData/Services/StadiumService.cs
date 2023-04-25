using SportsData.Data;
using SportsData.Data.Models;
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

        public bool CheckIfStadiumExists(AddStadiumModel model)
        {
            var stad = context.Stadiums.FirstOrDefault(s => s.Name == model.StadiumName);
            if (stad == null)
            {
                return false;
            }
            return true;

        }

        public void AddStadium(AddStadiumModel model)
        {
            var stad = new Stadium();
            stad.Capacity = model.Capacity;
            stad.Name = model.StadiumName;
            context.Stadiums.AddRange(stad);
            context.SaveChanges();
        }

        public bool StadiumIsIn(string model)
        {
            var stadIsIn = context.Stadiums.FirstOrDefault(s => s.Name == model);
            if (stadIsIn != null)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var stadium = context.Stadiums.First(s => s.Id == id);
            var stadiumAssigned = context.Teams.FirstOrDefault(t => t.StadiumID == id);
            if (stadiumAssigned != null)
            {
                return false;
            }
            context.Stadiums.Remove(stadium);
            context.SaveChanges();
            return true;
        }

        public bool Edit(AddStadiumModel model, int Id)
        {
            var stadFind = context.Stadiums.FirstOrDefault(s => s.Id == Id);
            if (stadFind == null)
            {
                return false;  
            }

            stadFind.Name = model.StadiumName;
            stadFind.Capacity = model.Capacity;
            context.SaveChanges();
            return true;

        }
    }
}
