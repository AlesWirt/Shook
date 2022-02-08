using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading.Tasks;
using iTechArt.Shook.DomainModel;

namespace iTechArt.Shook.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SurveyApplicationDbContext>();

                await dbContext.Database.MigrateAsync();

                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

                await AddInitialDataAsync(userManager);
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(
                    new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build());
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });


        private async static Task AddInitialDataAsync(UserManager<User> userManager)
        {
            var user = new User()
            {
                UserName = "Steve",
                Email = "wirt94@mail.ru"
            };

            var identityResult = await userManager.CreateAsync(user, "123456");

            if (identityResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, RoleNames.Admin);
            }
        }
    }
}
