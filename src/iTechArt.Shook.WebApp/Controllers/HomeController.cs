﻿using iTechArt.Common;
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


        public HomeController(ILog logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
