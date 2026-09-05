using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentInfrastructure.Persistence.Seeders
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(this IHost app)
        {
            using var scope = app.Services.CreateScope();

            var adminSeed = scope.ServiceProvider
                .GetRequiredService<AdminSeed>();

            await adminSeed.SeedAdminAsync();
        }
    }
}
