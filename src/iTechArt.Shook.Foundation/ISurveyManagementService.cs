using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public interface ISurveyManagementService
    {
        public Task<Survey> GetSurveyByIdAsync(int id);

        public Task UpdateSurveyAsync(Survey fromSurvey, Survey toSurvey);

        public Task<IReadOnlyCollection<Survey>> GetAllSurveysAsync();

        public Task<IReadOnlyCollection<Survey>> GetUserSurveysAsync(int userId);

        public Task CreateSurveyAsync(Survey survey);

        public Task CreateSurveyAsync(Survey survey, IEnumerable<Question> questions);
    }
}
