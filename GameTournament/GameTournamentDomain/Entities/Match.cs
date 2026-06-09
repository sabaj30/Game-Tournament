using GameTournamentDomain.Common;
using GameTournamentDomain.Enums;

namespace GameTournamentDomain.Entities
{
    public class Match : BaseEntity<int>
    {
        public string Title { get; set; } = null!;

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;

        public int RoundNumber { get; set; }
        public int MatchNumber { get; set; }

        public int? FirstParticipantId { get; set; }
        public TournamentParticipant? FirstParticipant { get; set; }

        public int? SecondParticipantId { get; set; }
        public TournamentParticipant? SecondParticipant { get; set; }

        public int? FirstParticipantScore { get; set; }
        public int? SecondParticipantScore { get; set; }

        public int? WinnerParticipantId { get; set; }
        public TournamentParticipant? WinnerParticipant { get; set; }

        public int? NextMatchId { get; set; }
        public Match? NextMatch { get; set; }

        public MatchSlot? WinnerGoesToSlot { get; set; }

        public MatchStatus Status { get; set; } = MatchStatus.Scheduled;
        public int? FirstTeamId { get; set; }
        public Team? FirstTeam { get; set; }

        public int? SecondTeamId { get; set; }
        public Team? SecondTeam { get; set; }

        public int? WinnerTeamId { get; set; }
        public Team? WinnerTeam { get; set; }
    }


}
