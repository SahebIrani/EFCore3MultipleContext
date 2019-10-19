using Demo.Data;

namespace Demo.Services
{
    public class LogService
    {
        public LogService(LogDbContext logDbContext) => LogDbContext = logDbContext;

        public LogDbContext LogDbContext { get; }
    }
}
