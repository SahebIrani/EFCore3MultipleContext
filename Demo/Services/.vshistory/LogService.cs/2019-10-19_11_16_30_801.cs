using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Demo.Data;
using Demo.Models;

using Microsoft.EntityFrameworkCore;

namespace Demo.Services
{
    public class LogService : ILogService
    {
        public LogService(LogDbContext logDbContext) => LogDbContext = logDbContext;

        public LogDbContext LogDbContext { get; }

        public async Task<IEnumerable<Person>> PeopleAsync(CancellationToken cancellationToken = default)
        {
            await LogDbContext.People.AddAsync(new Person { Id = 1, FullName = "SinjulMSBH" }, cancellationToken);
            await LogDbContext.People.AddAsync(new Person { Id = 2, FullName = "JackSlater" }, cancellationToken);
            await LogDbContext.SaveChangesAsync(cancellationToken);
            var people = LogDbContext.People.ToListAsync(cancellationToken);
            return people;
        }
    }
}
