using GameTournamentApplication.Services.AuthServices;
using GameTournamentApplication.Services.AuthServices.DTOs;
using GameTournamentApplication.Services.GameServices;
using GameTournamentApplication.Services.GameServices.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace GameTournamentWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] CreateGameDTO createGameDTO,CancellationToken cancellationToken)
        {
            var result = await _gameService.AddGameAsync(createGameDTO, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _gameService.GetAllAsync(cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Value);
        }


        [HttpGet("{gameId:int}")]
        public async Task<IActionResult> GetById(int gameId, CancellationToken cancellationToken)
        {
            var result = await _gameService.GetByIdAsync(gameId, cancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }

            return Ok(result.Value);
        }


        [HttpPut("{gameId:int}")]
        public async Task<IActionResult> UpdateGame(int gameId, [FromBody] UpdateGameDTO updateGameDTO,CancellationToken cancellationToken)
        {
            var result = await _gameService.UpdateGameAsync(
                updateGameDTO,
                gameId,
                cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }


        [HttpDelete("{gameId:int}")]
        public async Task<IActionResult> DeleteGame(int gameId, CancellationToken cancellationToken)
        {
            var result = await _gameService.DeleteGameAsync(
                gameId,
                cancellationToken);

            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }

            return Ok();
        }
    }

}
