using System.Diagnostics;
using System.Linq;

using Demo.Data;
using Demo.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext applicationDbContext,
            LogDbContext logDbContext,
            AlphaDbContext alphaDbContext)
        {
            _logger = logger;
            ApplicationDbContext = applicationDbContext;
            LogDbContext = logDbContext;
            AlphaDbContext = alphaDbContext;
        }

        private readonly ILogger<HomeController> _logger;

        public ApplicationDbContext ApplicationDbContext { get; }
        public LogDbContext LogDbContext { get; }
        public AlphaDbContext AlphaDbContext { get; }

        public async System.Threading.Tasks.Task<IActionResult> IndexAsync()
        {
            var test = ApplicationDbContext.People.ToList();
            var test2 = LogDbContext.People.ToList();

            await AlphaDbContext.People.AddAsync(new Person { Id = 1, FullName = "SinjulMSBH" });
            await AlphaDbContext.People.AddAsync(new Person { Id = 2, FullName = "JackSlater" });
            await AlphaDbContext.SaveChangesAsync();
            var people = await AlphaDbContext.People.ToListAsync();

            return Ok(people);
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
