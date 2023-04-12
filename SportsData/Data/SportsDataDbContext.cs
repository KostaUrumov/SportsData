﻿using Microsoft.EntityFrameworkCore;
using SportsData.Constraints;
using SportsData.Data.Models;

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

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Team> Teams { get; set; }   


    }
}