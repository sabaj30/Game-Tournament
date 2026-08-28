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
        public DbSet<User> Users => Set<User>();
        //public DbSet<ChatRoom> ChatRooms => Set<ChatRoom>();
       // public DbSet<Currency> Currency => Set<Currency>();
        //public DbSet<Wallet> Wallets => Set<Wallet>();

    }
}
