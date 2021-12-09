using iTechArt.Common;
using iTechArt.Common.Interface;
using iTechArt.Repositories;
using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.Foundation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace iTechArt.Shook.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClickerDbContext>(options => options.UseInMemoryDatabase(databaseName: "UnitOfWork"));
            services.AddScoped<IUnitOfWork, UnitOfWork<ClickerDbContext>>();
            services.AddScoped<IClickerService, ClickerService>();
            services.AddControllersWithViews();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
