using iTechArt.Repositories;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.Foundation;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ClickerCounter _counter;


        public HomeController()
        {
            _counter = new ClickerCounter();
        }

        public IActionResult Index()
        {
            return View(_counter.Clicker);
        }

        [HttpPost]
        public IActionResult IncreaseClicker()
        {
            var clicker = _counter.IncreaseClicker();
            return View("Index", clicker);
        }
    }
}
