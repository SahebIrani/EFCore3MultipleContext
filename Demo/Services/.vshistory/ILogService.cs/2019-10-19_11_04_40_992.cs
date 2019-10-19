using System.Collections.Generic;

using Demo.Models;

namespace Demo.Services
{
    public interface ILogService
    {
        IAsyncEnumerable<Person> PeopleAsync();
    }
}