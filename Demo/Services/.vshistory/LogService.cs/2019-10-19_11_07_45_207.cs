using System.Collections.Generic;

using Demo.Data;
using Demo.Models;

using Microsoft.EntityFrameworkCore;

namespace Demo.Services
{
    public class LogService : ILogService
    {
        public LogService(LogDbContext logDbContext) => LogDbContext = logDbContext;

        public LogDbContext LogDbContext { get; }

        public async IAsyncEnumerable<Person> PeopleAsync()
        {
            await LogDbContext.People.AddAsync(new Person { Id = 1, FullName = "SinjulMSBH" });
            await LogDbContext.People.AddAsync(new Person { Id = 2, FullName = "JackSlater" });
            await LogDbContext.SaveChangesAsync();
            var people = LogDbContext.People.AsAsyncEnumerable();
            await foreach (Person person in people)
                yield return person;
        }
    }
}
