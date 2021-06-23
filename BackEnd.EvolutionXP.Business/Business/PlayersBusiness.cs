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
    public class PlayersBusiness : IPlayersBusiness
    {
        private readonly IPlayersRepository _playersRepository;

        public PlayersBusiness(IPlayersRepository playersRepository )
        {
            _playersRepository = playersRepository;
        }

        public async Task<ResponseBase<List<Players>>> AddPlayer(List<Players> players)
        {
            var response = new ResponseBase<List<Players>>();
            try
            {
                var result = await _playersRepository.AddAsync(players).ConfigureAwait(true);
                if (result.Count > 0 )
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Jugador insertado correctamente";
                    response.Data = result;
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "Oppss... Jugador no se inserto";
                    response.Data = result;
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<List<Players>>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ResponseBase<bool>> DeletePlayer(string id)
        {
            var response = new ResponseBase<bool>();
            try
            {
                var result = await _playersRepository.DeleteAsync(id).ConfigureAwait(true);
                if (result)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Jugador insertado correctamente";
                    response.Data = result;
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "Oppss... Jugador no se inserto";
                    response.Data = result;
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<bool>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ResponseBase<List<Players>>> GetAllPlayers()
        {
            var response = new ResponseBase<List<Players>>();
            try
            {
                var result = await _playersRepository.GetAll().ConfigureAwait(true);
                if (result.Count > 0)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Solicitud Ok";
                    response.Data = result;
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "Ningun jugador encontrado";
                    response.Data = result;
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<List<Players>>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ResponseBase<bool>> UpdatePlayer(Players players)
        {
            var response = new ResponseBase<bool>();
            try
            {
                var result = await _playersRepository.UpdateAsync(players).ConfigureAwait(true);
                if (result)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Jugador actualizado correctamente";
                    response.Data = result;
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "Oppss... Jugador no se inserto";
                    response.Data = result;
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<bool>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }
    }
}
