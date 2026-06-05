using GameTournamentDomain.Common;

namespace GameTournamentDomain.Entities
{
    public class Team : BaseEntity<int>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Match> FirstTeamMatches { get; set; } = new List<Match>();
        public ICollection<Match> SecondTeamMatches { get; set; } = new List<Match>();
        public ICollection<Match> WonMatches { get; set; } = new List<Match>();
    }
