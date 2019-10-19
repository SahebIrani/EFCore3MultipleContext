using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class BaseDbContext : IdentityDbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options, LogDbContext logDbContext) : base(options)
        {
        }



    }

    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }



    }
}
