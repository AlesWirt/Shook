﻿using iTechArt.Shook.Foundation;
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
    //[Authorize]
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
                Title = survey.Title,
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

            var userId = Helper.GetUserIdClaimsPrincipal(User);

            var questions = new List<Question>();

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

            return RedirectToAction("Index", "Survey");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int roleId)
        {
            var survey = await _surveyManagementService.GetSurveyByIdAsync(roleId);

            var surveyViewModel = new SurveyViewModel
            {
                Id = survey.Id,
                Title = survey.Title
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