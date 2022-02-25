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
            var survey = await _uow.SurveyRepository.GetByIdAsync(id);

            if (survey == null)
            {
                _logger.LogError($"Survey does not exist with th given id");

                throw new ArgumentNullException($"Survey does not exist with th given id");
            }

            return survey;
        }

        public async Task<IReadOnlyCollection<Survey>> GetAllSurveysAsync(int userId)
        {
            var collection = await _uow.SurveyRepository.GetAllSurveysAsync(userId);

            if (collection == null)
            {
                _logger.LogError($"User does not have surveys");

                throw new ArgumentNullException($"User does not have surveys");
            }

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

            var newQuestions = new List<Question>();

            foreach(var question in toSurvey.Questions)
            {
                var existQuestion = fromSurvey.Questions.SingleOrDefault(q => q.Id == question.Id);

                if(existQuestion != null)
                {
                    existQuestion.Title = question.Title;
                    _uow.GetRepository<Question>().Update(existQuestion);
                }
                else
                {
                    newQuestions.Add(question);
                }
            }

            foreach(var question in fromSurvey.Questions)
            {
                var existedQuestion = toSurvey.Questions.SingleOrDefault(q => q.Id == question.Id);

                if(existedQuestion == null)
                {
                    _uow.GetRepository<Question>().Delete(question);
                }
            }

            fromSurvey.Questions.AddRange(newQuestions);

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
    }
}
