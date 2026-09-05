using GameTournamentApplication.Common.Results;
using GameTournamentApplication.Services.GameServices.DTOs;

namespace GameTournamentApplication.Services.GameServices
{
    public interface IGameService
    {
        Task<Result<List<GameDTO>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<GameDTO>> GetByIdAsync(int gameId, CancellationToken cancellationToken);
        Task<Result> AddGameAsync(CreateGameDTO createGameDTO, CancellationToken cancellationToken);
        Task<Result> UpdateGameAsync(UpdateGameDTO updateGameDTO,int gameId, CancellationToken cancellationToken);
        Task<Result> DeleteGameAsync(int gameId, CancellationToken cancellationToken);
    }
}
