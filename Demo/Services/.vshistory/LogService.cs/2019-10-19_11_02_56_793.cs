using System.Collections.Generic;
using System.Threading;

using Demo.Data;
using Demo.Models;

using Microsoft.EntityFrameworkCore;

namespace Demo.Services
{
    public class LogService
    {
        public LogService(LogDbContext logDbContext) => LogDbContext = logDbContext;

        public LogDbContext LogDbContext { get; }

        public async IAsyncEnumerable<Person> PeopleAsync(CancellationToken cancellationToken = default)
        {
            await LogDbContext.People.AddAsync(new Person { Id = 1, FullName = "SinjulMSBH" }, cancellationToken);
            await LogDbContext.People.AddAsync(new Person { Id = 2, FullName = "JackSlater" }, cancellationToken);
            await LogDbContext.SaveChangesAsync(cancellationToken);

            await foreach (var item in LogDbContext.People.AsAsyncEnumerable())
                yield return item;
        }
    }
}
