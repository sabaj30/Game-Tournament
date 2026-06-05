using GameTournamentDomain.Common;

namespace GameTournamentDomain.Entities
{
    public class TournamentParticipant : BaseEntity<int>
    {
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;

        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

        public int Seed { get; set; }

        public bool IsEliminated { get; set; }
    }
}
