using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.EvolutionXP.Entities.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;


namespace EvolutionXP.Controllers.v1
{
    [Route("api/Movimients")]
    [ApiController]
    public class MovimientsController : ControllerBase
    {
        private readonly IMovimientsBusiness _movimientsBusiness;

        public MovimientsController(IMovimientsBusiness movimientsBusiness)
        {
            _movimientsBusiness = movimientsBusiness;
        }

        [HttpGet]
        public async Task<ActionResult> GetMovimients()
        {
            var response = await _movimientsBusiness.GetMovimients();
            return StatusCode(response.Code, response);
        }
    }
}
