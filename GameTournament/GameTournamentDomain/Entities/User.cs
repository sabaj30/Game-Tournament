using GameTournamentDomain.Common;
using GameTournamentDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentDomain.Entities
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.Player;


        public Player Player { get; set; }



    }
}
