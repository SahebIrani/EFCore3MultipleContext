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
            var people = await LogDbContext.People.ToListAsync(cancellationToken);
            return people;
        }
    }
}
