using GameTournamentDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentDomain.Entities
{
    public class Player : BaseEntity<int>
    {

        public string Nickname { get; set; }
        public int TotalScore { get; set; }
        public int UserId { get; set; }


        public User User { get; set; }
        public ICollection<Team> Teams { get; set; } = [];
    }
}
