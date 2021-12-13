using iTechArt.Common;
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
            _logger.Log(LogLevel.Info, "Clicker view");
            _service.Insert();

            return View(_service.GetClicker());
        }


        [HttpPost]
        public IActionResult IncreaseClicker()
        {
            _logger.Log(LogLevel.Info, "Clicker increased");
            
            return View("Index", _service.Update());
        }
    }
}
