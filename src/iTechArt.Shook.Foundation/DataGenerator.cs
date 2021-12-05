using iTechArt.Repositories;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.DomainModel.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Shook.Foundation
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new ClickerDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ClickerDbContext>>());
            using(var uow = new GenericUnitOfWork<ClickerDbContext>())
            {
                uow.GenericRepository<Clicker, ClickerDbContext>().Insert(
                    new Clicker()
                    {
                        Id = 1,
                        ClickerCounter = 0
                    });
                uow.Save();
            }
        }
    }
}
