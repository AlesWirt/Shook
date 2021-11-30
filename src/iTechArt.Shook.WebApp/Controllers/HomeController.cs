using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"Controller action executed on: {DateTime.Now.TimeOfDay}");
            return View(Repository.Clicker);
        }

        [HttpPost]
        public IActionResult IncreaseClicker()
        {
            Repository.IncreaseClicker();
            return View("Index", Repository.Clicker);
        }
    }
}
