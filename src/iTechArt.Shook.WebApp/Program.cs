using iTechArt.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace iTechArt.Shook.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger =            
                new LoggerConfiguration()
                .WriteTo.File("Logs\\logs.txt")
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
