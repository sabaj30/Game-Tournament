using GameTournamentDomain.Common;

namespace GameTournamentDomain.Entities
{
    public class Game : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<TournamentGame> TournamentGames { get; set; } = [];
    }
}
