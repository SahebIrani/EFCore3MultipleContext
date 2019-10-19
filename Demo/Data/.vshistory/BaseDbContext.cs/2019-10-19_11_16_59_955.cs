using Demo.Models;
using Demo.Services;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Demo.Data
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> People { get; set; }
    }

    public class AlphaDbContext : BaseDbContext
    {
        public AlphaDbContext(DbContextOptions<AlphaDbContext> options) : base(options) { }
    }

    public class BetaDbContext : BaseDbContext
    {
        public BetaDbContext(DbContextOptions<BetaDbContext> options) : base(options) { }
    }

    public class GammaDbContext : BaseDbContext
    {
        public GammaDbContext(DbContextOptions<GammaDbContext> options) : base(options) { }
    }


    public class BaseDbContext<T> : IdentityDbContext where T : IdentityDbContext
    {
        public BaseDbContext(DbContextOptions<T> options) : base(options) { }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var logService = this.GetService<ILogService>();
            var people = logService.PeopleAsync().GetAwaiter().GetResult();

            //var logDbCintext = this.GetService<IServiceProvider>().CreateScope().ServiceProvider.GetRequiredService<LogDbContext>();
            //var scope = this.GetInfrastructure().GetRequiredService<IServiceProvider>();
            //var logDbCintext = scope.CreateScope().ServiceProvider.GetRequiredService<LogDbContext>();
            //LogDbContext logDbCintext = this.GetService<LogDbContext>();
            //LogDbContext logDbCintext2 = this.GetInfrastructure().GetRequiredService<LogDbContext>();
            //var ctx = ((IInfrastructure<IServiceProvider>)this).GetService<LogDbContext>();
            //logDbCintext.People.Add(new Person { FullName = "SinjulMBH" });
            //logDbCintext2.People.Add(new Person { Id = 2, FullName = "JackSlater" });
            //logDbCintext.SaveChanges();
            //var people = logDbCintext.People.ToList();
        }
    }

    public class ApplicationDbContext : BaseDbContext<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    public class LogDbContext : BaseDbContext<LogDbContext>
    {
        public LogDbContext(DbContextOptions<LogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
