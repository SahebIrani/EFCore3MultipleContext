using System.Linq;

using Demo.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Demo.Data
{
    public class BaseDbContext : IdentityDbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options, LogDbContext logDbContext) : base(options)
            => LogDbContext = logDbContext;
        public LogDbContext LogDbContext { get; }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            LogDbContext logDbCintext = this.GetService<LogDbContext>();
            var addPersion = logDbCintext.People.Add(new Person { FullName = "SinjulMBH" });
            logDbCintext.SaveChanges();
            var addPersion2 = LogDbContext.People.Add(new Person { FullName = "SinjulMBH" });
            LogDbContext.SaveChanges();
            var people = logDbCintext.People.ToList();
            var LogDbContext2 = logDbCintext.People.ToList();
        }
    }

    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(DbContextOptions<BaseDbContext> options, LogDbContext logDbContext) : base(options, logDbContext)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            LogDbContext logDbCintext = this.GetService<LogDbContext>();
            var addPersion = logDbCintext.People.Add(new Person { FullName = "SinjulMBH" });
            logDbCintext.SaveChanges();
            var addPersion2 = LogDbContext.People.Add(new Person { FullName = "SinjulMBH" });
            LogDbContext.SaveChanges();
            var people = logDbCintext.People.ToList();
            var LogDbContext2 = logDbCintext.People.ToList();
        }
    }

    public class LogDbContext : BaseDbContext
    {
        public LogDbContext(DbContextOptions<BaseDbContext> options, LogDbContext logDbContext) : base(options, logDbContext)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            LogDbContext logDbCintext = this.GetService<LogDbContext>();
            var addPersion = logDbCintext.People.Add(new Person { FullName = "SinjulMBH" });
            logDbCintext.SaveChanges();
            var addPersion2 = LogDbContext.People.Add(new Person { FullName = "SinjulMBH" });
            LogDbContext.SaveChanges();
            var people = logDbCintext.People.ToList();
            var LogDbContext2 = logDbCintext.People.ToList();
        }
    }
}
