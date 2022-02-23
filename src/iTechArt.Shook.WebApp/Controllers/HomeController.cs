using iTechArt.Shook.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Create()
        {
            var surveyViewModel = new SurveyViewModel();
            return PartialView("_Survey", surveyViewModel);
        }
        
        [HttpPost]
        public ActionResult PostAddMore(SurveyViewModel model)
        {
            return View();
        }
    }
}