using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;

namespace EvolutionXP.Controllers.v1
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameBusiness _gameBusiness;

        public GameController(IGameBusiness gameBusiness)
        {
            _gameBusiness = gameBusiness;
        }

        [HttpGet]
        public async Task<ActionResult> GetGamesById()
        {
            var response = await _gameBusiness.GetGames();
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<ActionResult> InsertGame([FromBody] Game game)
        {
            var response = await _gameBusiness.InsertGames(game);
            return StatusCode(response.Code, response);
        }
    }
}
