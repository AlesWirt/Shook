using iTechArt.Repositories;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.Foundation;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ClickerCounter _counter;

        public HomeController(ClickerDbContext context)
        {
            _counter = new ClickerCounter(context);
        }

        public IActionResult Index()
        {
            return View(Repository.Clicker);
        }

        [HttpPost]
        public IActionResult IncreaseClicker()
        {
            var clicker = _counter.IncreaseClicker();
            return View("Index", clicker);
        }
    }
}
