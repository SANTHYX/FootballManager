using FootballManagerApp.EntityFramework;
using FootballManagerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly FootballDbContext context;

        public PlayerRepository(FootballDbContext _context)
        {
            context = _context;
        }

        public void Delete(Player player)
        {
            context.Player.Remove(player);
        }

        public void Add(Player player)
        {
            context.Player.Add(player);
        }

        public async Task<Player> GetAsync(int? id)
            => await context.Player.Include(x=>x.Team).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Player>> GetAllAsync()
            => await context.Player.AsNoTracking().Include(x=>x.Team).ToListAsync();

        public IEnumerable<Player> GetAll()
            => context.Player.AsNoTracking().ToList();

        public void Update(Player player)
        {
            context.Player.Update(player);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task FindsAsync(int id)
           =>await context.Player.FindAsync(id);       
    }
}
