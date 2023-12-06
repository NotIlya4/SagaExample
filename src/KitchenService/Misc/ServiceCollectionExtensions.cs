using KitchenService.Domain;
using KitchenService.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;
using Npgsql;

namespace KitchenService.Misc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKitchenDbContext(this IServiceCollection services, string conn)
    {
        services.AddDbContextFactory<KitchenDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseNpgsql(conn, builder => builder.EnableRetryOnFailure());
        });

        return services;
    }

    public static IServiceCollection AddKitchenServices(this IServiceCollection services)
    {
        services.AddSingleton<ISystemClock, SystemClock>();
        services.AddSingleton<TicketFactory>();
        services.AddSingleton<TicketServiceFactory>();

        services.AddScoped<TicketEstimater>();
        services.AddScoped<BusyHoursProvider>();

        return services;
    }
}