using System.Threading;
using System.Threading.Tasks;

using Demo.Models;
using Demo.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

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
        private string _tenantHost;
        private int _tenantId;

        public LogDbContext(DbContextOptions<LogDbContext> options, ILogService logService, IHttpContextAccessor accessor)
            : base(options)
        {
            LogService = logService;
            _tenantHost = accessor.HttpContext.Request.Host.Value;
        }

        public ILogService LogService { get; }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            LogDbContext logDbCintext = this.GetService<LogDbContext>();
            var res = await logDbCintext.People.ToListAsync(cancellationToken);

            var people0 = await LogService.PeopleAsync(cancellationToken);

            var logService = this.GetService<ILogService>();
            var people = await logService.PeopleAsync(cancellationToken);

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
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

            //LogDbContext logDbCintext1 = this.GetService<IServiceProvider>().CreateScope().ServiceProvider.GetRequiredService<LogDbContext>();
            //LogDbContext logDbCintext2 = this.GetService<IServiceScopeFactory>().CreateScope().ServiceProvider.GetRequiredService<LogDbContext>();
            //LogDbContext logDbCintext3 = this.GetInfrastructure().GetRequiredService<LogDbContext>();
            //LogDbContext logDbCintext4 = ((IInfrastructure<IServiceProvider>)this).GetService<LogDbContext>();

            var res = await People.ToListAsync(cancellationToken);

            var people0 = await LogService.PeopleAsync(cancellationToken);

            var logService = this.GetService<ILogService>();
            var people = await logService.PeopleAsync(cancellationToken);

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
