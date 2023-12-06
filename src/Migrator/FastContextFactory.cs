using Microsoft.EntityFrameworkCore;
using Shared.Misc;

namespace Migrator;

public class FastContextFactory
{
    private readonly IConfiguration _config;

    public FastContextFactory(IConfiguration config)
    {
        _config = config;
    }
    
    public TDbContext CreateContext<TDbContext>(string section, Func<DbContextOptions, TDbContext> factory) where TDbContext : DbContext
    {
        var conn = _config.GetPostgresConn(section);
        var assemblyName = typeof(TDbContext).Assembly.FullName;
        var options = new DbContextOptionsBuilder()
            .UseNpgsql(conn, optionsBuilder => optionsBuilder.MigrationsAssembly(assemblyName)).Options;
        return factory(options);
    }
}