using System;
using System.Linq;

using Demo.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Data
{
    public class BaseDbContext<T> : IdentityDbContext where T : IdentityDbContext
    {
        public BaseDbContext(DbContextOptions<T> options, IServiceProvider serviceProvider) : base(options) => ServiceProvider = serviceProvider;

        public DbSet<Person> People { get; set; }
        public IServiceProvider ServiceProvider { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            LogDbContext logDbCintext = ServiceProvider.CreateScope().ServiceProvider.GetRequiredService<LogDbContext>();
            logDbCintext.People.Add(new Person { Id = 1, FullName = "SinjulMBH" });
            logDbCintext.SaveChanges();
            var people = logDbCintext.People.ToList();
        }
    }

    public class ApplicationDbContext : BaseDbContext<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IServiceProvider serviceProvider)
            : base(options, serviceProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    public class LogDbContext : BaseDbContext<LogDbContext>
    {
        public LogDbContext(DbContextOptions<LogDbContext> options, IServiceProvider serviceProvider)
            : base(options, serviceProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
