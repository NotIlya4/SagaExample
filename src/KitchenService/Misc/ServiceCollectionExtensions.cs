using KitchenService.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace KitchenService.Misc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, string conn)
    {
        services.AddDbContextFactory<AppDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseNpgsql(conn, builder => builder.EnableRetryOnFailure());
        });

        return services;
    }

    public static string GetConn(this IConfiguration config, string section = "ConnectionString")
    {
        return config.GetValue<NpgsqlConnectionStringBuilder>(section)!.ConnectionString;
    }
}