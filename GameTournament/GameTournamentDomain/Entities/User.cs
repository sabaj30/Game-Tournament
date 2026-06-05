using GameTournamentDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentDomain.Entities
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
