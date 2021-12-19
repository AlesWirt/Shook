using iTechArt.Common;
using iTechArt.Shook.Repositories.DbContexts;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.Units;
using iTechArt.Shook.Foundation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace iTechArt.Shook.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>
                (options => options.UseSqlServer
                (Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<ILog, Logger>();
            services.AddControllersWithViews();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserDbContext>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("user",
                    "",
                    new { Controller = "User", action = "Create" });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
