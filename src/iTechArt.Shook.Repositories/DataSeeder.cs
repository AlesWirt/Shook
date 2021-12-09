using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Repositories
{
    public class DataSeeder 
    {
        public UnitOfWork<ClickerDbContext> UnitOfWork { get; }

        public DataSeeder(ClickerDbContext context)
        {
            UnitOfWork = new UnitOfWork<ClickerDbContext>(context);
        }

        public void Initialize(ClickerDbContext context)
        {
            using (UnitOfWork)
            {
                UnitOfWork.GetRepository<Clicker>().Insert(
                    new Clicker()
                    {
                        Id = 1,
                        ClickerCounter = 0
                    });
                UnitOfWork.SaveChangesAsync();
            }
        }
    }
}
