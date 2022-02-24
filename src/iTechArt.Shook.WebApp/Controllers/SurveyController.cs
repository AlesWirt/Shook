using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.Helpers;
using iTechArt.Shook.WebApp.ViewModels;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace iTechArt.Shook.WebApp.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        private readonly ISurveyManagementService _surveyManagementService;


        public SurveyController(ISurveyManagementService surveyManagementService)
        {
            _surveyManagementService = surveyManagementService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = Helper.GetUserIdClaimsPrincipal(User);

            var surveys = await _surveyManagementService.GetAllSurveysAsync(userId);

            var surveyViewModel = surveys.Select(survey =>
            new SurveyViewModel
            {
                Id = survey.Id,
                Name = survey.Title,
            }).ToList();

            return View(surveyViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SurveyViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            var model = new QuestionViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SurveyViewModel surveyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(surveyViewModel);
            }

            var userId = Helper.GetUserIdClaimsPrincipal(User);

            var questions = new List<Question>();

            var survey = new Survey
            {
                OwnerId = userId,
                Title = surveyViewModel.Name,
                Questions = surveyViewModel.Questions
                    .Select(q => new Question
                    {
                        Id = q.Id,
                        Title = q.Title
                    }).ToList()
            };

            foreach (var questionModel in surveyViewModel.Questions)
            {
                questions.Add(new Question
                {
                    Survey = survey
                });
            }
            
            await _surveyManagementService.CreateSurveyAsync(survey);

            return RedirectToAction("Index", "Survey");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int roleId)
        {
            var survey = await _surveyManagementService.GetSurveyByIdAsync(roleId);

            var surveyViewModel = new SurveyViewModel
            {
                Id = survey.Id,
                Name = survey.Title
            };

            return View(surveyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SurveyViewModel surveyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(surveyViewModel);
            }

            var surveyEdit = new Survey
            {
                Title = surveyViewModel.Name,
                Questions = surveyViewModel.Questions.Select(q => new Question
                {
                    Id = q.Id,
                    Title = q.Title
                }).ToList()
            };

            var survey = await _surveyManagementService.GetSurveyByIdAsync(surveyViewModel.Id);

            await _surveyManagementService.UpdateSurveyAsync(survey, surveyEdit);

            return RedirectToAction("Index", "Survey");
        }
    }
}