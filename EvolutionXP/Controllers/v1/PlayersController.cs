using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.EvolutionXP.Entities.DbSet;
using BackEnd.EvolutionXP.Entities.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;

namespace EvolutionXP.Controllers.v1
{
    [Route("api/Players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersBusiness _playersBusiness;
        public PlayersController(IPlayersBusiness playersBusiness)
        {
            _playersBusiness = playersBusiness;
        }

        [HttpGet]
        public async Task<ActionResult>  GetPlayers()
        {
            var response = await _playersBusiness.GetAllPlayers();
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlayer([FromBody] List<Players> players)
        {
            var response = await _playersBusiness.AddPlayer(players);
            return StatusCode(response.Code, response);
        }

        [HttpPut]
        public async Task<ActionResult> Updatelayer([FromBody] Players players)
        {
            var response = await _playersBusiness.UpdatePlayer(players);
            return StatusCode(response.Code, response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePlayer([FromQuery] string id)
        {
            var response = await _playersBusiness.DeletePlayer(id);
            return StatusCode(response.Code, response);
        }
    }
}
