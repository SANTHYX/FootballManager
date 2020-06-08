using FootballManagerApp.EntityFramework;
using FootballManagerApp.Models;
using FootballManagerApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly FootballDbContext context;

        public TrainerRepository(FootballDbContext _context)
        {
            context = _context;
        }

        public void Add(Trainer trainer)
        {
            context.Trainer.Add(trainer);
        }

        public void Delete(Trainer trainer)
        {
            context.Trainer.Remove(trainer);
        }

        public IEnumerable<Trainer> GetAll()
            => context.Trainer.AsNoTracking().ToList();

        public async Task FindsAsync(int? id)
           => await context.Team.FindAsync(id);

        public async Task<IEnumerable<Trainer>> GetAllAsync()
            => await context.Trainer.ToListAsync();

        public async Task<Trainer> GetAsync(int? id)
           => await context.Trainer.SingleOrDefaultAsync(x => x.Id == id);
        
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Trainer trainer)
        {
            context.Trainer.Update(trainer);
        }
    }
}
