using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        public Task<IReadOnlyCollection<Survey>> GetAllSurveysAsync();

        public Task<IReadOnlyCollection<Question>> GetQuestionsBySurveyIdAsync(int surveyId);
    }
}
