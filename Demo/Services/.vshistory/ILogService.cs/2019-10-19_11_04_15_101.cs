using System.Collections.Generic;
using Demo.Data;
using Demo.Models;

namespace Demo.Services
{
    public interface ILogService
    {
        LogDbContext LogDbContext { get; }

        IAsyncEnumerable<Person> PeopleAsync();
    }
}