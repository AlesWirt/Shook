using iTechArt.Common;
using iTechArt.Shook.Foundation;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using iTechArt.Shook.Repositories.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<SurveyApplicationDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddSingleton<ILog, Logger>();
            services.AddScoped<ISurveyUnitOfWork, SurveyUnitOfWork>();

            var builder = services.AddIdentityCore<User>(options =>
            {
            });
            builder.AddRoles<UserRole>();
            builder.AddUserStore<SurveyUserStore>();
            builder.AddRoleStore<RoleStore>();
            builder.AddSignInManager<SignInManager<User>>();

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
    