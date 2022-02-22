using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {

        }

        public async Task CreateRangeAsync(IEnumerable<Question> collection)
        {
            await DbContext.Set<Question>().AddRangeAsync(collection);
        }
    }
}
