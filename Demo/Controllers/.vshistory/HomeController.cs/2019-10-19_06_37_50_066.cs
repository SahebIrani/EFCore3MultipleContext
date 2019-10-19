using System.Diagnostics;

using Demo.Data;
using Demo.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext applicationDbContext,
            LogDbContext logDbContext)
        {
            _logger = logger;
            ApplicationDbContext = applicationDbContext;
            LogDbContext = logDbContext;
        }

        private readonly ILogger<HomeController> _logger;

        public ApplicationDbContext ApplicationDbContext { get; }
        public LogDbContext LogDbContext { get; }

        public IActionResult Index()
        {
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
