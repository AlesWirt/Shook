using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Foundation
{
    public class ClickerService : IClickerService
    {
        private readonly DataSeeder _seeder;
        private Clicker _clicker;


        public Clicker Clicker { get; }

        public Clicker Insert()
        {
            _clicker = new Clicker()
            {
                Id = 1,
                ClickerCounter = 0
            };
            _seeder.UnitOfWork.GetRepository<Clicker>().InsertAsync(_clicker);
            _seeder.UnitOfWork.SaveChangesAsync();
            return _clicker;
        }
        public Clicker GetClicker()
        {
                return _seeder.UnitOfWork
                .GetRepository<Clicker>()
                .GetByIdAsync((int)1).Result;
        }
        public ClickerService(IUnitOfWork uow)
        {
            _seeder = new DataSeeder(uow);
        }

        public Clicker Update()
        {
            _clicker.ClickerCounter += 1;
            _seeder.UnitOfWork.GetRepository<Clicker>().Update(_clicker);
            return _clicker;
        }

    }
}
