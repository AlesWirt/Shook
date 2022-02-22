using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.ViewModels;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using iTechArt.Shook.DomainModel;

namespace iTechArt.Shook.WebApp.Controllers
{
    [Authorize(Roles =RoleNames.User)]
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
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isConverted = int.TryParse(userIdClaim, out var userId);

            var surveys = await _surveyManagementService.GetUserSurveysAsync(userId);

            var surveyViewModel = surveys.Select(survey =>
            new SurveyViewModel
            {
                Id = survey.Id,
                Name = survey.Title,
                Questions = survey.Questions.Select(q => q.Title).ToList()
            }).ToList();

            return View(surveyViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SurveyViewModel surveyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(surveyViewModel);
            }

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isConverted = int.TryParse(userIdClaim, out var userId);

            var questions = new List<Question>();

            var survey = new Survey
            {
                OwnerId = userId,
                Title = surveyViewModel.Name,
            };

            foreach (var questionModel in surveyViewModel.Questions)
            {
                questions.Add(new Question
                {
                    Title = questionModel,
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
                Title = surveyViewModel.Name
            };

            var survey = await _surveyManagementService.GetSurveyByIdAsync(surveyViewModel.Id);

            await _surveyManagementService.UpdateSurveyAsync(survey, surveyEdit);

            return RedirectToAction("Index", "Survey");
        }
    }
}
