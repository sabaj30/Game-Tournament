using GameTournamentDomain.Common;
using GameTournamentDomain.Enums;

namespace GameTournamentDomain.Entities
{
    public class TournamentGame : BaseEntity<int>
    {
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public GameMode Mode { get; set; }
    }
}
