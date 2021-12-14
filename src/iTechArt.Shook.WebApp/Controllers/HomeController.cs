using iTechArt.Common;
using iTechArt.Shook.Foundation;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            _logger.Log(LogLevel.Info, "Launching Index view.");
            await _service.InsertAsync();

            return View(await _service.GetClickerAsync());
        }


        [HttpPost]
        public async Task<IActionResult> IncreaseClicker()
        {
            _logger.Log(LogLevel.Info, "Clicker increased");
            
            return View("Index", await _service.UpdateAsync());
        }
    }
}
