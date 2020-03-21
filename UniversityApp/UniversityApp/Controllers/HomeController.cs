using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityApp.Models;
using UniversityApp.Services.Repository.Interfaces;

namespace UniversityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IAddressRepository iar;

        public HomeController(ILogger<HomeController> logger, IAddressRepository iar)
        {
            _logger = logger;
            this.iar = iar;
        }

        public async Task<IActionResult> Index()
        {
            var x = await iar.GetAddressByStreetAsync("This Street");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
