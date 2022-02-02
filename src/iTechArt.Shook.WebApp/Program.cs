using iTechArt.Common;
using iTechArt.Shook.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading.Tasks;
using System;
using iTechArt.Shook.Repositories.Data;

namespace iTechArt.Shook.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<SurveyApplicationDbContext>();

                    await dbContext.Database.MigrateAsync();

                    SeedData.Initialize(services, "123456").Wait();
                }
                catch(Exception ex)
                {
                    var logger = services.GetService<ILog>();
                    logger.LogError("An error occured seeding the DB", ex);
                }
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
    }
}
