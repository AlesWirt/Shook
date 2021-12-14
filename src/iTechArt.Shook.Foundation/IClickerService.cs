using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public interface IClickerService
    {
        public Task<Clicker>InsertAsync();

        public Task<Clicker> GetClickerAsync();

        public Task<Clicker> UpdateAsync(int id = 1);
    }
}
