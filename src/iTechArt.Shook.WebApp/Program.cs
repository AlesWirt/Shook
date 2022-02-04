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
                var services = scope.ServiceProvider;

                var dbContext = scope.ServiceProvider.GetRequiredService<SurveyApplicationDbContext>();

                await dbContext.Database.MigrateAsync();

                var userManager = services.GetService<UserManager<User>>();

                await AddInitialDataAsync(userManager, "Steve", "wirt94@mail.ru", "123456");
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


        private async static Task AddInitialDataAsync(UserManager<User> userManager, string userName, string email, string password)
        {
            var user = await userManager.FindByNameAsync("Steve");
            if (user == null)
            {
                var passwordHasher = new PasswordHasher<User>();

                var passwordHash = passwordHasher.HashPassword(user, password);

                user = new User()
                {
                    UserName = userName,
                    NormalizedName = userName.ToUpper(),
                    Email = email,
                    PasswordHash = passwordHash
                };

                var identityResult = await userManager.CreateAsync(user);

                if (identityResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, RoleNames.Admin);
                    await userManager.AddToRoleAsync(user, RoleNames.User);
                }
            }
        }
    }
}
