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


        public Clicker Clicker { get; }


        public ClickerService(IClickerUnitOfWork uow, ILog logger)
        {
            _clickerUnitOfWork = uow;
            _logger = logger;
        }


        public async Task InsertAsync(Clicker clickerEntity)
        {
            _logger.Log(LogLevel.Info, "Inserting Clicker entity into In-Memory database");
            await _clickerUnitOfWork.ClickerRepository.CreateAsync(clickerEntity);
            await _clickerUnitOfWork.SaveChangesAsync();
        }

        public async Task<Clicker> GetClickerAsync(params object[] values)
        {
                return await _clickerUnitOfWork
                .ClickerRepository
                .GetByIdAsync(values);
        }

        public async Task UpdateAsync(Clicker clickerEntity)
        {
            _clickerUnitOfWork.ClickerRepository.Update(clickerEntity);
            await _clickerUnitOfWork.SaveChangesAsync();
        }
    }
}
