using GameTournamentApplication.Common.Results;
using GameTournamentApplication.Services.AuthServices.DTOs;

namespace GameTournamentApplication.Services.AuthServices
{
    public interface IAuthService
    {
        Task<Result<string>> AuthenticateUserAsync(string username, string password, CancellationToken cancellationToken);
        Task<Result> RegisterUserAsync(RegisterRequest request, CancellationToken cancellationToken);

    }
}
