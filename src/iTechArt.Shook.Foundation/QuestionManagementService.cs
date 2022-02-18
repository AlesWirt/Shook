using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public class QuestionManagementService : IQuestionManagementService
    {
        private readonly ILog _logger;
        private readonly ISurveyUnitOfWork _uow;

        
        public QuestionManagementService(ILog logger, ISurveyUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        public async Task CreateQuestionAsync(Question question)
        {
            await _uow.QuestionRepository.CreateAsync(question);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            _uow.QuestionRepository.Update(question);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(Question question)
        {
            _uow.QuestionRepository.Delete(question);
            await _uow.SaveChangesAsync();
        }

        public void AddQuestionToSurvey(Survey survey, Question question)
        {
            question.SurveyId = survey.Id;
        }
    }
}
