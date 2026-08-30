using GameTournamentDomain.Entities;

namespace GameTournamentApplication.Services.JwtServices
{
    public interface IJwtService
    {
        string GenerateToken(User user, CancellationToken cancellationToken);
    }
}
