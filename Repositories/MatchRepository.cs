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
    public class MatchRepository : IMatchRepository
    {
        private readonly FootballDbContext context;

        public MatchRepository(FootballDbContext _context)
        {
            context = _context;
        }

        public void Add(Match match)
        {
            context.Match.Add(match);
        }

        public void Delete(Match match)
        {
            context.Match.Remove(match);
        }

        public async Task<Match> FindsAsync(int? id)
            =>await context.Match.FindAsync(id);

        public async Task<Match> GetAsync(int? id)
            => await context.Match.Include(x=>x.Team).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Match>> GetAllAsync()
            => await context.Match.Include(x=>x.Team).AsNoTracking().ToListAsync();

        public IEnumerable<Match> GetAll()
           => context.Match.AsNoTracking().ToList();

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Match match)
        {
            context.Match.Update(match);
        }
    }
}
