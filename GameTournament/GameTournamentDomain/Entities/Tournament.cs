using GameTournamentDomain.Common;
using GameTournamentDomain.Enums;

namespace GameTournamentDomain.Entities
{
    public class Tournament : BaseEntity<int>
    {
        public string Title { get; set; } = null!;

        public int GameId { get; set; }
        public Game Game { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime StartRegisterTime { get; set; }
        public DateTime EndRegisterTime { get; set; }

        public TournamentStatus Status { get; set; } = TournamentStatus.Draft;

    }
}
