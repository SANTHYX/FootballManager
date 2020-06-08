using FootballManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Repositories.Interfaces
{
    public interface ITrainingRepository
    {
        void Add(Training training);

        void Delete(Training training);

        Task<Training> GetAsync(int? id);

        Task<IEnumerable<Training>> GetAllAsync();

        IEnumerable<Training> GetAll();

        void Update(Training training);

        Task SaveAsync();
    }
}
