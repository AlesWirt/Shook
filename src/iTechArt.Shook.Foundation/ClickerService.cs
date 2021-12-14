using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.Units;
using iTechArt.Common;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public class ClickerService : IClickerService
    {
        private readonly ILog _logger;

        
        private readonly IClickerUnitOfWork _clickerUnitOfWork;
        

        private Clicker _clicker;


        public Clicker Clicker { get; }


        public ClickerService(IClickerUnitOfWork uow, ILog logger)
        {
            _clickerUnitOfWork = uow;
            _logger = logger;
        }


        public async Task<Clicker> InsertAsync()
        {
            _logger.Log(LogLevel.Info, "Inserting Clicker entity into In-Memory database");
            _clicker = new Clicker()
            {
                Id = 1,
                ClickerCounter = 0
            };

            await _clickerUnitOfWork.ClickerRepository.CreateAsync(_clicker);
            await _clickerUnitOfWork.SaveChangesAsync();

            return _clicker;
        }

        public async Task<Clicker> GetClickerAsync()
        {
                return _clickerUnitOfWork
                .ClickerRepository
                .GetByIdAsync((int)1).Result;
        }

        public async Task<Clicker> UpdateAsync(int id = 1)
        {
            _clicker = GetClickerAsync().Result;
            _clicker.ClickerCounter += 1;
            _clickerUnitOfWork.ClickerRepository.Update(_clicker);
            await _clickerUnitOfWork.SaveChangesAsync();

            return _clicker;
        }
    }
}
