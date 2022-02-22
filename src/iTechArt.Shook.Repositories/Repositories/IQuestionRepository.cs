using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public Task CreateRangeAsync(IEnumerable<Question> collection);
    }
}
