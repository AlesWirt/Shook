using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.Units;
using iTechArt.Common;
using System.Threading.Tasks;
using System;

namespace iTechArt.Shook.Foundation
{
    public class ClickerService : IClickerService
    {
        private readonly ILog _logger;
        private readonly IClickerUnitOfWork _clickerUnitOfWork;


        public ClickerService(IClickerUnitOfWork uow, ILog logger)
        {
            _clickerUnitOfWork = uow;
            _logger = logger;
        }


        public async Task InsertAsync(Clicker clickerEntity)
        {
            _logger.LogInformation("Inserting Clicker entity into In-Memory database");
            await _clickerUnitOfWork.ClickerRepository.CreateAsync(clickerEntity);
            await _clickerUnitOfWork.SaveChangesAsync();
        }

        public async Task<Clicker> GetClickerAsync(int id)
        {

            var clicker =  await _clickerUnitOfWork
            .ClickerRepository
            .GetByIdAsync(id);

            if(clicker == null)
            {
                var error =  new ArgumentNullException();
                _logger.LogError($"{typeof(ClickerService).GetMethod("GetClikcerAsync").Name} method get wrong id number", error);
                throw error;
            }

            return clicker;
        }

        public async Task UpdateAsync(Clicker clickerEntity)
        {
            _clickerUnitOfWork.ClickerRepository.Update(clickerEntity);
            await _clickerUnitOfWork.SaveChangesAsync();
        }
    }
}
