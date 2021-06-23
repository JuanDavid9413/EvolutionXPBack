using BackEnd.EvolutionXP.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Entities.Interfaces.Repository
{
    public interface IPlayersRepository
    {
        Task<List<Players>> AddAsync(List<Players> players);
        Task<bool> UpdateAsync(Players players);
        Task<bool> DeleteAsync(string values);
        Task<List<Players>> GetAll();
        Task<List<Players>> GetFilter(Expression<Func<Players, bool>> expression);
    }
}
