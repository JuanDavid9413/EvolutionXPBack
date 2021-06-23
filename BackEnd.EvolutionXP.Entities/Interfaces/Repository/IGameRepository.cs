using BackEnd.EvolutionXP.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Entities.Interfaces.Repository
{
    public interface IGameRepository
    {
        Task<Game> AddAsync(Game game);
        Task<bool> DeleteAsync(int id);
        Task<List<Game>> GetAll();
        Task<List<Game>> GetFilter(Expression<Func<Game, bool>> expression);
        Task<bool> UpdateAsync(Game game);
    }
}
