using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Foundation.Units;
using iTechArt.Shook.Foundation.Repositories;

namespace iTechArt.Shook.Foundation
{
    public class ClickerService : IClickerService
    {
        private readonly IClickerUnitOfWork _clickerUnitOfWork;


        private readonly ClickerRepository _repository;
        
        private Clicker _clicker;


        public Clicker Clicker { get; }


        public ClickerService(IClickerUnitOfWork uow)
        {
            _clickerUnitOfWork = uow;
            _repository = (ClickerRepository)_clickerUnitOfWork.GetRepository<Clicker>();
        }


        public Clicker Insert()
        {
            _clicker = new Clicker()
            {
                Id = 1,
                ClickerCounter = 0
            };
            _clickerUnitOfWork.GetRepository<Clicker>().CreateAsync(_clicker);
            _clickerUnitOfWork.SaveChangesAsync();
            return _clicker;
        }

        public Clicker GetClicker()
        {
                return _clickerUnitOfWork
                .GetRepository<Clicker>()
                .GetByIdAsync((int)1).Result;
        }

        public Clicker Update()
        {
            _clicker.ClickerCounter += 1;
            _clickerUnitOfWork.GetRepository<Clicker>().UpdateAsync(_clicker);
            return _clicker;
        }
    }
}
