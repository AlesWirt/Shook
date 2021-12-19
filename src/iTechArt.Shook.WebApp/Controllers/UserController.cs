using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
