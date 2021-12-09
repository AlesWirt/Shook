using iTechArt.Shook.Foundation;
using iTechArt.Shook.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Shook.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //using(var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var contextService = services.GetRequiredService<ClickerDbContext>();
            //    var context = new ClickerDbContext(services.GetRequiredService<DbContextOptions<ClickerDbContext>>());
            //    DataGenerator.Initialize(context);
            //}
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
