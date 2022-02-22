using iTechArt.Shook.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TestGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TestPost(List<TestViewModel> testModel)
        {
            return View();
        }
    }
}