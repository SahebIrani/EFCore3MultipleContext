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
        public LogService(ApplicationDbContext context) => Context = context;

        public ApplicationDbContext Context { get; }

        public async Task<IEnumerable<Person>> PeopleAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Person> people = await Context.People.ToListAsync(cancellationToken);
            return people;
        }
    }
}
