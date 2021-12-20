using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public interface IClickerService
    {
        public Task InsertAsync(Clicker clickerEntity);

        public Task<Clicker> GetClickerAsync(int id);

        public Task UpdateAsync(Clicker clickerEntity);
    }
}
