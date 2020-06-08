using FootballManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Repositories.Interfaces
{
    public interface ITrainerRepository
    {
        void Add(Trainer trainer);

        void Update(Trainer trainer);

        void Delete(Trainer trainer);

        public Task FindsAsync(int? id);

        public Task<Trainer> GetAsync(int? id);

        Task<IEnumerable<Trainer>> GetAllAsync();

        IEnumerable<Trainer> GetAll();

        Task SaveAsync();
    }
}
