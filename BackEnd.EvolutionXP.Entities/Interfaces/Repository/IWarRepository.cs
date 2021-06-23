using BackEnd.EvolutionXP.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Entities.Interfaces.Repository
{
    public interface IWarRepository
    {
        Task<bool> AddAsync(War war);
        Task<List<War>> GetFilter();
        Task<List<War>> GetFilter(Expression<Func<War, bool>> expression);
    }
}
