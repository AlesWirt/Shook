using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Repositories
{
    public class DataSeeder 
    {
        public IUnitOfWork UnitOfWork { get; }

        public DataSeeder(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }
    }
}
