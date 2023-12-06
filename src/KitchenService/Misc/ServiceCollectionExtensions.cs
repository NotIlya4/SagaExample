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

        services.AddScoped<ITicketFactory, TicketFactory>();
        services.AddScoped<ITicketEstimater, TicketEstimater>();
        services.AddScoped<IBusyHoursProvider, BusyHoursProvider>();

        return services;
    }
}