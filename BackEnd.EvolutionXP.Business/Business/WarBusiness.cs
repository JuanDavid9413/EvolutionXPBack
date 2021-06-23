using BackEnd.EvolutionXP.Business.Proccesor;
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
    public class WarBusiness : IWarBusiness
    {
        private readonly IWarRepository _warRepository;

        public WarBusiness(IWarRepository warRepository)
        {
            _warRepository = warRepository;
        }

        public async Task<ResponseBase<bool>> CreateWar(War war)
        {
            var response = new ResponseBase<bool>();
            try
            {
                response.Data = await _warRepository.AddAsync(war).ConfigureAwait(true);
                if (response.Data)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Insertado correctamente";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Oppps... ocurrio un error al insertar";
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<bool>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ResponseBase<List<War>>> GetWar()
        {
            var response = new ResponseBase<List<War>>();
            try
            {
                response.Data = await _warRepository.GetFilter().ConfigureAwait(true);
                if (response.Data.Count > 0)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Solicitud OK";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Oppps... ocurrio un error al buscar la información";
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<List<War>>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ResponseBase<List<War>>> GetFilterWar(int idGame)
        {
            var response = new ResponseBase<List<War>>();
            try
            {
                response.Data = await _warRepository.GetFilter(l => l.Id_Game == idGame).ConfigureAwait(true);
                if (response.Data.Count > 0)
                {
                    response.Code = (int)HttpStatusCode.OK;
                    response.Message = "Solicitud OK";
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "Ningun item encontrado";
                }
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<List<War>>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ResponseBase<bool>> GetWinnerRounds()
        {
            var response = new ResponseBase<bool>();
            try
            {
                var resultado = prueba.GetWinnerPlayer();
            }
            catch (Exception ex)
            {
                response.ResponseBaseCatch<bool>(true, ex.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }
    }
}
