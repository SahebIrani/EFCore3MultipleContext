using Demo.Models;

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


        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            LogDbContext logDbCintext = this.GetService<LogDbContext>();
        }
    }

    public class LogDbContext : BaseDbContext
    {
        public LogDbContext(DbContextOptions<BaseDbContext> options, LogDbContext logDbContext) : base(options, logDbContext)
        {
        }



    }
}
