using BackEnd.EvolutionXP.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Entities.Interfaces.Repository
{
    public interface IMovimientsRepository
    {
        Task<List<Movimients>> GetAll();
    }
}
