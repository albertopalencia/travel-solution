using Identity.Models;
using Identity.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var rolManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await DefaultRoles.SeedAsync(userManager, rolManager);
            await DefaultAdminUser.SeedAsync(userManager, rolManager);
            await DefaultBasicUser.SeedAsync(userManager, rolManager);
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
