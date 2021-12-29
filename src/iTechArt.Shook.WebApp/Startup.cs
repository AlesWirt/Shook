using iTechArt.Common;
using iTechArt.Shook.Repositories.DbContexts;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using iTechArt.Shook.Foundation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Identity;

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
            services.AddDbContext<SurveyApplicationDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddSingleton<ILog, Logger>();

            var builder = services.AddIdentityCore<User>();
            builder.AddUserStore<User>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddScoped<ISurveyUnitOfWork, SurveyUnitOfWork>();
            services.AddScoped<IUserManagementService, UserManagementService>();
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
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
