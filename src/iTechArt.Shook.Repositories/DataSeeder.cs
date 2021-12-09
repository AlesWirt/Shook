using iTechArt.Repositories.Interfaces;

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
