using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using System;
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

        public async Task<IReadOnlyCollection<Survey>> GetAllSurveysAsync()
        {
            var collection = await _uow.SurveyRepository.GetAllSurveysAsync();

            return collection;
        }

        public async Task UpdateSurveyAsync(Survey fromSurvey, Survey toSurvey)
        {
            if (fromSurvey == null || toSurvey == null)
            {
                _logger.LogError($"Surveys entities can not be null");

                throw new ArgumentNullException($"Surveys entities can not be null");
            }

            fromSurvey.Name = toSurvey.Name;

            _uow.SurveyRepository.Update(fromSurvey);
            await _uow.SaveChangesAsync();
        }
    }
}
