using iTechArt.Shook.DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Shook.Repositories
{
    public class ClickerDbContext : DbContext
    {
        public DbSet<Clicker> Clickers { get; set; }
        public ClickerDbContext(DbContextOptions<ClickerDbContext> options) : base(options)
        {

        }
    }
}
