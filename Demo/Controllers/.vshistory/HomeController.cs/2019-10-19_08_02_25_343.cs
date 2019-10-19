using System.Diagnostics;
using System.Linq;

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
            LogDbContext logDbContext,
            ExtendedDBContext extendedDBContext)
        {
            _logger = logger;
            ApplicationDbContext = applicationDbContext;
            LogDbContext = logDbContext;
            ExtendedDBContext = extendedDBContext;
        }

        private readonly ILogger<HomeController> _logger;

        public ApplicationDbContext ApplicationDbContext { get; }
        public LogDbContext LogDbContext { get; }
        public ExtendedDBContext ExtendedDBContext { get; }

        public IActionResult Index()
        {
            var test = ApplicationDbContext.People.ToList();
            var test2 = LogDbContext.People.ToList();

            ExtendedDBContext.People.Add(new Person { Id = 1, FullName = "SinjulMSBH" });
            ExtendedDBContext.SaveChanges();
            var p = ExtendedDBContext.People.ToList();

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
