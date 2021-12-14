using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.Units;
using iTechArt.Common;

namespace iTechArt.Shook.Foundation
{
    public class ClickerService : IClickerService
    {
        private ILog _logger;

        
        private readonly IClickerUnitOfWork _clickerUnitOfWork;
        

        private Clicker _clicker;


        public Clicker Clicker { get; }


        public ClickerService(IClickerUnitOfWork uow, ILog logger)
        {
            _clickerUnitOfWork = uow;
            _logger = logger;
        }


        public Clicker Insert()
        {
            _logger.Log(LogLevel.Info, "Inserting Clicker entity into In-Memory database");
            _clicker = new Clicker()
            {
                Id = 1,
                ClickerCounter = 0
            };
            _clickerUnitOfWork.ClickerRepository.CreateAsync(_clicker);
            _clickerUnitOfWork.SaveChangesAsync();

            return _clicker;
        }

        public Clicker GetClicker()
        {
                return _clickerUnitOfWork
                .ClickerRepository
                .GetByIdAsync((int)1).Result;
        }

        public Clicker Update(int id = 1)
        {
            _clicker = GetClicker();
            _clicker.ClickerCounter += 1;
            _clickerUnitOfWork.ClickerRepository.Update(_clicker);
            _clickerUnitOfWork.SaveChangesAsync();

            return _clicker;
        }
    }
}
