using GameTournamentDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentInfrastructure.Persistence
{
    public class ChampionDbContext : DbContext
    {
        public ChampionDbContext(DbContextOptions<ChampionDbContext> options)
            : base(options)
        {

        }

        public DbSet<Player> Players => Set<Player>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        public DbSet<TournamentParticipant> TournamentParticipants => Set<TournamentParticipant>();
        public DbSet<Match> Matches => Set<Match>();

    }
}
