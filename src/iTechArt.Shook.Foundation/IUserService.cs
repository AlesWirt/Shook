using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public interface IUserService
    {
        public Task CreateAsync(User userEntity);
    }
}
