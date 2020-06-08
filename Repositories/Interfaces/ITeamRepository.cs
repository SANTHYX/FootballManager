using FootballManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        void Add(Team team);

        void Update(Team team);

        void Delete(Team team);

        Task<Team> GetAsync(int? id);

        Task<IEnumerable<Team>> GetAsyncAll();

        IEnumerable<Team> GetAll();

        Task SaveAsync();

        Task FindsAsync(int id);
    }
}
