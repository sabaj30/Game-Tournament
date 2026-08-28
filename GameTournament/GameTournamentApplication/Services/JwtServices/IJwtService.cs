using GameTournamentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentApplication.Services.JwtServices
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
