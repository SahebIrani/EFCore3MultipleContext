using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Demo.Data
{
    public class BaseDbContext : IdentityDbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options, LogDbContext logDbContext) : base(options)
        {
            LogDbContext = logDbContext;
        }

        public LogDbContext LogDbContext { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            LogDbContext logDbCintext = this.GetService<LogDbContext>();

        }
    }

    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }



    }
}
