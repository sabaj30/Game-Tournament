using GameTournamentDomain.Entities;
using GameTournamentDomain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentInfrastructure.Persistence.Seeders
{
    public class AdminSeed
    {
        private readonly ChampionDbContext _championDbContext;
        private readonly PasswordHasher<User> _passwordHasher;

        public AdminSeed(ChampionDbContext championDbContext, PasswordHasher<User> passwordHasher)
        {
            _championDbContext = championDbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task SeedAdminAsync(CancellationToken cancellationToken = default)
        {
            var adminExists = await _championDbContext.Users
                .AnyAsync(x => x.Role == UserRole.Admin, cancellationToken);

            if (adminExists)
            {
                return;
            }

            var adminPassword = "Admin@123456";

            var admin = new User
            {
                UserName = "admin",
                Email = "sabajafaricc@gmail.com",
                Role = UserRole.Admin
            };

            admin.PasswordHash = _passwordHasher.HashPassword(admin, adminPassword);

            await _championDbContext.Users.AddAsync(admin, cancellationToken);

            await _championDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
