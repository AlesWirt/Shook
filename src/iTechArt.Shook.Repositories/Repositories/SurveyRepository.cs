using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {


        public SurveyRepository(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {

        }


        public async Task<IReadOnlyCollection<Survey>> GetAllSurveysAsync()
        {
            var collection = await DbContext.Set<Survey>()
                .Include(s => s.Questions)
                .ToListAsync();

            return collection;
        }

        public async Task<IReadOnlyCollection<Survey>> GetUserSurveysAsync(int userId)
        {
            var collection = await DbContext.Set<Survey>()
                .Include(s => s.Owner)
                .Include(s => s.Questions)
                .Where(s => s.OwnerId == userId)
                .ToListAsync();

            return collection;
        }

        public async Task<IReadOnlyCollection<Question>> GetQuestionsBySurveyIdAsync(int surveyId)
        {
            var collection= await DbContext.Set<Question>().Include(q => q.Survey).Where(s => s.Id == surveyId).ToListAsync();

            return collection;
        }
    }
}
