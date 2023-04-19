using Microsoft.EntityFrameworkCore;
using SportsData.Constraints;
using SportsData.Data.Models;
using System.Configuration;

namespace SportsData.Data
{
    public class SportsDataDbContext : DbContext
    {
        public SportsDataDbContext()
        {
            
        }

        public SportsDataDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(GlobalConstraints.connect);
            }
        }

        internal void AddStadium(Stadium stad)
        {
           
        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Team> Teams { get; set; }   
        public DbSet<Stadium> Stadiums { get; set; }


    }
}
