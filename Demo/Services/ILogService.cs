using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Demo.Models;

namespace Demo.Services
{
    public interface ILogService
    {
        Task<IEnumerable<Person>> PeopleAsync(CancellationToken cancellationToken = default);
    }
}