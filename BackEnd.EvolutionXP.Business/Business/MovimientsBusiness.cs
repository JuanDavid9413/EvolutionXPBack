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
    public class MovimientsBusiness : IMovimientsBusiness
    {
        private readonly IMovimientsRepository _movimientsRepository;
        public MovimientsBusiness(IMovimientsRepository movimientsRepository)
        {
            _movimientsRepository = movimientsRepository;
        }

        public async Task<ResponseBase<List<Movimients>>> GetMovimients()
        {
            var response = new ResponseBase<List<Movimients>>();
            try
            {
                response.Data = await _movimientsRepository.GetAll().ConfigureAwait(true);
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
                response.ResponseBaseCatch<List<Movimients>>(true, ex.Message, HttpStatusCode.OK);
            }

            return response;
        }
    }
}
