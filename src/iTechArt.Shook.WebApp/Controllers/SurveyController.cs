using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.Helpers;
using iTechArt.Shook.WebApp.ViewModels;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            var userId = User.GetUserId();

            var surveys = await _surveyManagementService.GetAllSurveysAsync(userId);
            
            var surveyViewModel = surveys.Select(survey =>
                new SurveyViewModel
                {
                    Id = survey.Id,
                    Title = survey.Title,
                    Questions = survey.Questions.Select(q => 
                        new QuestionViewModel()
                        {
                            Id = q.Id,
                            Title =q.Title
                        }).ToList()
                }).ToList();

            return View(surveyViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var surveyViewModel = new SurveyViewModel();
            return View(surveyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SurveyViewModel surveyViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(surveyViewModel);
            }
            
            if(surveyViewModel.Id != 0)
            {
                var surveyTopical = new Survey()
                {
                    Id = surveyViewModel.Id,
                    Title = surveyViewModel.Title,
                    Questions = surveyViewModel.Questions.Select(q =>
                    new Question()
                    {
                        Id = q.Id,
                        Title = q.Title
                    }).ToList()
                };

                var surveyOutdated = await _surveyManagementService.GetSurveyByIdAsync(surveyViewModel.Id);

                await _surveyManagementService.UpdateSurveyAsync(surveyOutdated, surveyTopical);
            }
            else
            {
                var userId = User.GetUserId();

                var survey = new Survey
                {
                    OwnerId = userId,
                    Title = surveyViewModel.Title,
                    Questions = surveyViewModel.Questions
                        .Select(q => new Question
                        {
                            Title = q.Title
                        }).ToList()
                };

                await _surveyManagementService.CreateSurveyAsync(survey);
            }

            return RedirectToAction("Index", "Survey");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int surveyId)
        {

            if(surveyId != 0)
            {
                var survey = await _surveyManagementService.GetSurveyByIdAsync(surveyId);
                var userId = User.GetUserId();

                if (userId != survey.OwnerId)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }
                else
                {
                    var surveyViewModel = new SurveyViewModel
                    {
                        Id = survey.Id,
                        Title = survey.Title,
                        Questions = survey.Questions.Select(q => 
                            new QuestionViewModel()
                            {
                                Id = q.Id,
                                Title = q.Title
                            }).ToList()
                    };

                    return View("Editor", surveyViewModel);
                }
            }

            return View("Editor", new SurveyViewModel());
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
                Title = surveyViewModel.Title,
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