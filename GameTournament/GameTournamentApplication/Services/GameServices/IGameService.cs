using GameTournamentApplication.Common.Results;

namespace GameTournamentApplication.Services.GameServices
{
    public interface IGameService
    {
        Task<Result> AddGameAsync(CancellationToken cancellationToken);
    }
}
