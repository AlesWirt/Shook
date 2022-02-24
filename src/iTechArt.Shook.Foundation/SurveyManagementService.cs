using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public class SurveyManagementService : ISurveyManagementService
    {
        private readonly ILog _logger;
        private readonly ISurveyUnitOfWork _uow;


        public SurveyManagementService(ILog logger, ISurveyUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }


        public async Task<Survey> GetSurveyByIdAsync(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Identificator can not be null");

                throw new ArgumentNullException($"Identificator can not be null");
            }

            var survey = await _uow.SurveyRepository.GetByIdAsync(id);

            return survey;
        }

        public async Task<IReadOnlyCollection<Survey>> GetAllSurveysAsync(int userId)
        {
            var collection = await _uow.SurveyRepository.GetAllSurveysAsync(userId);

            return collection;
        }

        public async Task CreateSurveyAsync(Survey survey)
        {
            if (survey == null)
            {
                _logger.LogError($"Survey entity can not be null");

                throw new ArgumentNullException($"Survey entity can not be null");
            }

            await _uow.SurveyRepository.CreateAsync(survey);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateSurveyAsync(Survey fromSurvey, Survey toSurvey)
        {
            if (fromSurvey == null || toSurvey == null)
            {
                _logger.LogError($"Surveys entities can not be null");

                throw new ArgumentNullException($"Surveys entities can not be null");
            }

            foreach(var question in await _uow.SurveyRepository.GetQuestionsBySurveyIdAsync(toSurvey.Id))
            {
                if(!HasQuestion(fromSurvey.Questions, question.Id))
                {
                    _uow.GetRepository<Question>().Delete(question);
                }
                else
                {
                    question.Title = toSurvey.Questions.Find(q => q.Id == question.Id).Title;
                    _uow.GetRepository<Question>().Update(question);
                }
            }

            foreach(var question in fromSurvey.Questions)
            {
                if(!HasQuestion(await _uow.SurveyRepository.GetQuestionsBySurveyIdAsync(toSurvey.Id), question.Id))
                {
                    await _uow.GetRepository<Question>().CreateAsync(question);
                }
            }

            _uow.SurveyRepository.Update(fromSurvey);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteSurveyAsync(Survey survey)
        {
            if (survey == null)
            {
                _logger.LogError($"Survey entity can not be null");

                throw new ArgumentNullException($"Survey entity can not be null");
            }

            _uow.SurveyRepository.Delete(survey);
            await _uow.SaveChangesAsync();
        }

        private bool HasQuestion(IEnumerable<Question> questions, int questionId)
        {
            foreach(var question in questions)
            {
                if(question.Id == questionId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
