using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentDomain.Enums
{
    public enum TournamentStatus
    {
        Draft = 1,
        RegistrationOpen = 2,
        RegistrationClosed = 3,
        BracketGenerated = 4,
        InProgress = 5,
        Finished = 6,
        Cancelled = 7
    }
}
