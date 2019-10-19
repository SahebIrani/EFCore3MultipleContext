using System.Linq;

using Demo.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Demo.Data
{
    public class BaseDbContext<T> : IdentityDbContext where T : IdentityDbContext
    {
        public BaseDbContext(DbContextOptions<T> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            LogDbContext logDbCintext = this.GetService<LogDbContext>();
            logDbCintext.People.Add(new Person { Id = 1, FullName = "SinjulMBH" });
            logDbCintext.SaveChanges();
            var people = logDbCintext.People.ToList();
        }
    }

    public class ApplicationDbContext : BaseDbContext<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            LogDbContext logDbCintext = this.GetService<LogDbContext>();
            logDbCintext.People.Add(new Person { Id = 1, FullName = "SinjulMBH" });
            logDbCintext.SaveChanges();
            var people = logDbCintext.People.ToList();
        }
    }

    public class LogDbContext : BaseDbContext<LogDbContext>
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            LogDbContext logDbCintext = this.GetService<LogDbContext>();
            logDbCintext.People.Add(new Person { Id = 1, FullName = "SinjulMBH" });
            logDbCintext.SaveChanges();
            var people = logDbCintext.People.ToList();
        }
    }
}
