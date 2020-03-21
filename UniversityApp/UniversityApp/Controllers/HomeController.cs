using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;
using UniversityApp.Services.Repository.Interfaces;

namespace UniversityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAddressRepository iar;

        public HomeController(IAddressRepository iar)
        {
            this.iar = iar;
        }

        public async Task<IActionResult> Index()
        {
            var x = await iar.GetAddressByStudentIndexAsync("1241");

           // var t = await iar.GetByIdAsync(1);
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
