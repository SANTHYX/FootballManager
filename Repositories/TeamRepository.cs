using FootballManagerApp.EntityFramework;
using FootballManagerApp.Models;
using FootballManagerApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly FootballDbContext context;

        public TeamRepository(FootballDbContext _context)
        {
            context = _context;
        }

        public void Delete(Team team)
        {
            context.Team.Remove(team);
        }

        public void Add(Team team)
        {
            context.Team.Add(team);
        }

        public async Task<Team> GetAsync(int? id)
            => await context.Team.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Team>> GetAsyncAll()
            => await context.Team.ToListAsync();

        public IEnumerable<Team> GetAll()
            =>context.Team.AsNoTracking().ToList();

        public void Update(Team team)
        {
            context.Team.Update(team);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task FindsAsync(int id)
           =>await context.Team.FindAsync(id);
        
    }
}
