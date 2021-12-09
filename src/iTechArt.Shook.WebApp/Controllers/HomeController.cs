using iTechArt.Common.Interface;
using iTechArt.Shook.Foundation;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IClickerService _service;
        private ILog _logger;


        public HomeController(IClickerService service, ILog logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_service.GetClicker());
        }

        [HttpPost]
        public IActionResult IncreaseClicker()
        {
            var clicker = _service.Update();
            return View("Index", clicker);
        }
    }
}
