using KitchenService.Domain;
using KitchenService.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;
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

    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<ISystemClock, SystemClock>();
        services.AddSingleton<TicketFactory>();
        services.AddSingleton<TicketServiceFactory>();

        services.AddScoped<TicketEstimater>();
        services.AddScoped<BusyHoursProvider>();

        return services;
    }
}