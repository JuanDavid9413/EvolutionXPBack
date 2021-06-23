using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Interfaces.Business;
using BackEnd.EvolutionXP.Entities.Interfaces.Repository;
using BackEnd.EvolutionXP.Entities.Response;
using BackEnd.EvolutionXP.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EvolutionXP.Business.Business
{
    public class GameBusiness : IGameBusiness
    {
        private readonly IGameRepository _gameRepository;
        public GameBusiness(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<ResponseBase<List<Game>>> GetGames()
        {
            var response = new ResponseBase<List<Game>>();
            try
            {
                response.Data = await _gameRepository.GetAll().ConfigureAwait(true);
                if (response.Data.Count > 0)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Solicitud OK";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "Ningun registro encontrado";
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<List<Game>>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ResponseBase<Game>> InsertGames(Game games)
        {
            var response = new ResponseBase<Game>();
            try
            {
                response.Data = await _gameRepository.AddAsync(games).ConfigureAwait(true);
                if (response.Data != null)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Solicitud Ok";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Oppsss no se pudo crear el juego";
                }

            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<Game>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }
    }
}
