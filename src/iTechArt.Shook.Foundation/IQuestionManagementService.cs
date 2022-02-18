using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    interface IQuestionManagementService
    {
        public Task CreateQuestionAsync(Question question);

        public Task UpdateQuestionAsync(Question question);

        public Task DeleteQuestionAsync(Question question);

        public void AddQuestionToSurvey(Survey survey, Question question);
    }
}
