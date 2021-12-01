using iTechArt.Repositories;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork uow;

        public HomeController(ClickerDbContext context)
        {
            uow = new UnitOfWork(context);
        }

        public IActionResult Index()
        {
            return View(Repository.Clicker);
        }

        [HttpPost]
        public IActionResult IncreaseClicker()
        {
            Clicker clicker = uow.ClickerRepository.Read(1);
            clicker.ClickerCounter += 1;
            uow.ClickerRepository.Update(clicker);
            uow.SaveChanges();
            return View("Index", clicker);
        }
    }
}
