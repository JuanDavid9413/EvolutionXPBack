using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Entities.Interfaces.Business
{
    public interface IGameBusiness
    {
        Task<ResponseBase<Game>> InsertGames(Game games);
        Task<ResponseBase<List<Game>>> GetGames();
    }
}
