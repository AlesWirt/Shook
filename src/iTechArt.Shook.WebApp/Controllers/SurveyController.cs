using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.ViewModels;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace iTechArt.Shook.WebApp.Controllers
{
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
            var surveys = await _surveyManagementService.GetAllSurveysAsync();

            var surveyViewModel = surveys.Select(survey =>
            new SurveyViewModel
            {
                Id = survey.Id,
                Name = survey.Name,
                Questions = survey.Questions.Select(q => q.QuestionBody).ToList()
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

            var survey = new Survey
            {
                Name = surveyViewModel.Name
            };

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
                Name = survey.Name
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
                Name = surveyViewModel.Name
            };

            var survey = await _surveyManagementService.GetSurveyByIdAsync(surveyViewModel.Id);

            await _surveyManagementService.UpdateSurveyAsync(survey, surveyEdit);

            return RedirectToAction("Index", "Survey");
        }
    }
}
