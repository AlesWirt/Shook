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
        public static void Initialize(ClickerDbContext context)
        {
            using(var uow = new UnitOfWork<ClickerDbContext>(context))
            {
                uow.GetRepository<Clicker>().InsertAsync(
                    new Clicker()
                    {
                        Id = 1,
                        ClickerCounter = 0
                    });
                uow.SaveChangesAsync();
            }
        }
    }
}
