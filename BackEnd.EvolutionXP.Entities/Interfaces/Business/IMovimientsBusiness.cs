using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Entities.Interfaces.Business
{
    public interface IMovimientsBusiness
    {
        Task<ResponseBase<List<Movimients>>> GetMovimients();
    }
}
