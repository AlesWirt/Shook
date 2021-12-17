using iTechArt.Common;
using iTechArt.Shook.Foundation;
using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClickerService _service;
        private readonly ILog _logger;


        public HomeController(IClickerService service, ILog logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.Log(LogLevel.Info, "Launching Index view.");
            var clicker = new Clicker();
            await _service.InsertAsync(clicker);

            return View(clicker);
        }


        [HttpPost]
        public async Task<IActionResult> IncreaseClicker()
        {
            _logger.LogInformation("Clicker increased");
            var clicker = await _service.GetClickerAsync(1);
            ++clicker.Counter;
            await _service.UpdateAsync(clicker);
            return View("Index", clicker);
        }
    }
}
