using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Entities.Interfaces.Business
{
    public interface IWarBusiness
    {
        Task<ResponseBase<bool>> CreateWar(War war);
        Task<ResponseBase<List<War>>> GetWar();

        Task<ResponseBase<List<War>>> GetFilterWar(int idGame);
    }
}
