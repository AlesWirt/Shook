using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public interface IClickerService
    {
        public Task InsertAsync(Clicker clickerEntity);

        public Task<Clicker> GetClickerAsync(params object[] values);

        public Task UpdateAsync(Clicker clickerEntity);
    }
}
