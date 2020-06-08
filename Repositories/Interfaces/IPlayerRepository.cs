using FootballManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Repositories
{
    public interface IPlayerRepository
    {
        void Add(Player player);

        void Update(Player player);

        void Delete(Player player);

        Task<Player> GetAsync(int? id);

        public IEnumerable<Player> GetAll();

        Task <IEnumerable<Player>> GetAllAsync();

        Task SaveAsync();

        Task FindsAsync(int id);
    }
}
