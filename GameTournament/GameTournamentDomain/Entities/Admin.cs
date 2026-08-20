using GameTournamentDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentDomain.Entities
{
    public class Admin : BaseEntity<int>
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public User User { get; set; }
    }
}
