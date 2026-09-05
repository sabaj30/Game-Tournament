using GameTournamentApplication.Common.Results;
using GameTournamentApplication.Services.GameServices;
using GameTournamentApplication.Services.GameServices.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpPost]
        public async Task<Result> AddGame([FromBody] CreateGameDTO createGameDTO, CancellationToken cancellationToken)
        {
            return await _gameService.AddGameAsync(createGameDTO, cancellationToken);
        }


        [HttpGet]
        public async Task<Result<List<GameDTO>>> GetAll(CancellationToken cancellationToken)
        {
            return await _gameService.GetAllAsync(cancellationToken);
        }


        [HttpGet("{gameId:int}")]
        public async Task<Result<GameDTO>> GetById(int gameId,CancellationToken cancellationToken)
        {
            return await _gameService.GetByIdAsync(
                gameId,
                cancellationToken);
        }


        [HttpPut("{gameId:int}")]
        public async Task<Result> UpdateGame(
            int gameId,
            [FromBody] UpdateGameDTO updateGameDTO,
            CancellationToken cancellationToken)
        {
            return await _gameService.UpdateGameAsync(
                updateGameDTO,
                gameId,
                cancellationToken);
        }


        [HttpDelete("{gameId:int}")]
        public async Task<Result> DeleteGame(
            int gameId,
            CancellationToken cancellationToken)
        {
            return await _gameService.DeleteGameAsync(
                gameId,
                cancellationToken);
        }
    }
}

