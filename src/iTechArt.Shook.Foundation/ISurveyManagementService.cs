using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public interface ISurveyManagementService
    {
        public Task<Survey> GetSurveyByIdAsync(int id);

        public Task<IReadOnlyCollection<Survey>> GetAllSurveysAsync(int userId);

        public Task CreateSurveyAsync(Survey survey);

        public Task UpdateSurveyAsync(Survey fromSurvey, Survey toSurvey);

        public Task DeleteSurveyAsync(Survey survey);
    }
}
