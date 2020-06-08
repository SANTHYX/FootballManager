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
    public class TrainingRepository : ITrainingRepository
    {
        private readonly FootballDbContext context;

        public TrainingRepository(FootballDbContext _context)
        {
            context = _context;
        }

        public void Add(Training training)
        {
            context.Training.Add(training);
        }

        public void Delete(Training training)
        {
            context.Training.Remove(training);
        }

        public IEnumerable<Training> GetAll()
            =>context.Training.AsNoTracking().ToList();

        public async Task<IEnumerable<Training>> GetAllAsync()
            => await context.Training.Include(x=>x.Trainer).Include(x=>x.Team).ToListAsync();

        public async Task<Training> GetAsync(int? id)
            => await context.Training.Include(x=>x.Trainer).Include(x=>x.Team).SingleOrDefaultAsync(x => x.Id == id);

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Training training)
        {
            context.Training.Update(training);
        }
    }
}
