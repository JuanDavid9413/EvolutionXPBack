using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Entities.Interfaces.Business
{
    public interface IPlayersBusiness
    {
        Task<ResponseBase<List<Players>>> AddPlayer(List<Players> players);
        Task<ResponseBase<bool>> DeletePlayer(string id);
        Task<ResponseBase<bool>> UpdatePlayer(Players players);
        Task<ResponseBase<List<Players>>> GetAllPlayers();
    }
}
