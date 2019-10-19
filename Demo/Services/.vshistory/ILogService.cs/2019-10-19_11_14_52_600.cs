using System.Collections.Generic;
using System.Threading;

using Demo.Models;

namespace Demo.Services
{
    public interface ILogService
    {
        IEnumerable<Person> PeopleAsync(CancellationToken cancellationToken = default);
    }
}