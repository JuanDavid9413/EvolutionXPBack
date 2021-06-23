using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;

namespace EvolutionXP.Controllers.v1
{
    [Route("api/War")]
    [ApiController]
    public class WarController : ControllerBase
    {
        private readonly IWarBusiness _warBusiness;

        public WarController(IWarBusiness warBusiness)
        {
            _warBusiness = warBusiness;
        }

        [HttpGet]
        public async Task<ActionResult> GetWar()
        {
            var response = await _warBusiness.GetWar();
            return StatusCode(response.Code, response);
        }

        [HttpGet]
        [Route("GetWarFilter")]
        public async Task<ActionResult> GetWarFilter(int id_game)
        {
            var response = await _warBusiness.GetFilterWar(id_game);
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWar([FromBody] War war)
        {
            var response = await _warBusiness.CreateWar(war);
            return StatusCode(response.Code, response);
        }
    }
}
