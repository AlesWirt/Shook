using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {

        }
    }
}
