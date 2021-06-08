using BasketballWebApi.Models;
using BasketballWepApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<LeagueData> LeaguesData { get; set; }
        public DbSet<MatchData> MatchesData { get; set; }
        public DbSet<TeamData> TeamsData { get; set; }
        public DbSet<PlayerData> PlayersData { get; set; }
        public DbSet<Favourite> Favourite { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchData>().HasOne(m => m.League).WithMany(l => l.Matches);
            modelBuilder.Entity<TeamData>().HasOne(m => m.League).WithMany(l => l.Teams);
            modelBuilder.Entity<PlayerData>().HasOne(m => m.Team).WithMany(l => l.Players);

        }

    }
}
