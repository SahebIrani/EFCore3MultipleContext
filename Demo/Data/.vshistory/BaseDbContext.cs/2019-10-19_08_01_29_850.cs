
using Demo.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class BContext : DbContext
    {
        public BContext(DbContextOptions<BContext> options) : base(options) { }
    }

    public class AContext : DbContext
    {
        public AContext(DbContextOptions<AContext> options) : base(options) { }
    }

    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions<CoreDBContext> options) : base(options) { }
        protected CoreDBContext(DbContextOptions options) : base(options) { }
    }

    public class ExtendedDBContext : CoreDBContext
    {
        public ExtendedDBContext(DbContextOptions<ExtendedDBContext> options) : base(options) { }
    }






    public class BaseDbContext<T> : IdentityDbContext where T : IdentityDbContext
    {
        public BaseDbContext(DbContextOptions<T> options) : base(options) { }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
