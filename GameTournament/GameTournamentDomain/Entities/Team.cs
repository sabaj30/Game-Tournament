using GameTournamentDomain.Common;

namespace GameTournamentDomain.Entities
{
    public class Team : BaseEntity<int>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;

        public ICollection<Player> Players { get; set; }

    }
}
