using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {

        }
    }
}
