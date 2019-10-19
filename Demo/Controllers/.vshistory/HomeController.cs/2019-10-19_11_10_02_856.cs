using System.Diagnostics;
using System.Threading;

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

        public async System.Threading.Tasks.Task<IActionResult> IndexAsync(CancellationToken cancellationToken = default)
        {
            await ApplicationDbContext.People.AddAsync(new Person { Id = 1, FullName = "SinjulMSBH" }, cancellationToken);
            await AlphaDbContext.SaveChangesAsync(cancellationToken);
            var people1 = ApplicationDbContext.People.ToListAsync(cancellationToken);

            await LogDbContext.People.AddAsync(new Person { Id = 1, FullName = "SinjulMSBH" }, cancellationToken);
            await AlphaDbContext.SaveChangesAsync(cancellationToken);
            var people2 = LogDbContext.People.ToListAsync(cancellationToken);

            await AlphaDbContext.People.AddAsync(new Person { Id = 1, FullName = "SinjulMSBH" }, cancellationToken);
            await AlphaDbContext.People.AddAsync(new Person { Id = 2, FullName = "JackSlater" }, cancellationToken);
            await AlphaDbContext.SaveChangesAsync(cancellationToken);
            var people = await AlphaDbContext.People.ToListAsync(cancellationToken);

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
