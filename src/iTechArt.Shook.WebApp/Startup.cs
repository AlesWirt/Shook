using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using iTechArt.Shook.Foundation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

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
            services.AddDbContext<SurveyApplicationDbContext>
                (options => options.UseSqlServer
                (Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<ILog, Logger>();
            services.AddScoped<ISurveyUnitOfWork, SurveyUnitOfWork>();
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddIdentity<User, IdentityUser>().AddEntityFrameworkStores<SurveyApplicationDbContext>();
            services.AddControllersWithViews();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("create",
                    "",
                    new { Controller = "Home", action = "Create" });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
