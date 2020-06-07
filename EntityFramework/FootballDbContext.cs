using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballManagerApp.Models;

namespace FootballManagerApp.EntityFramework
{
    public class FootballDbContext:DbContext
    {
        public DbSet<FootballManagerApp.Models.Team> Team { get; set; }
        public DbSet<FootballManagerApp.Models.Player> Player { get; set; }
        public DbSet<FootballManagerApp.Models.Match> Match { get; set; }
        public DbSet<FootballManagerApp.Models.Trainer> Trainer { get; set; }
        public DbSet<FootballManagerApp.Models.Training> Training { get; set; }

        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =DESKTOP-79T8SJO\\DAMIANEK; User Id = sa; Password = abcd1234; Database = FootballDb");
        }
    }
}
