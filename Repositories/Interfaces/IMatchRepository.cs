using FootballManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        void Add(Match match);

        void Update(Match match);

        void Delete(Match match);

        Task<Match> FindsAsync(int? id);

        public Task<Match> GetAsync(int? id);

        Task<IEnumerable<Match>> GetAllAsync();

        IEnumerable<Match> GetAll();

        Task SaveAsync();
    }
}
