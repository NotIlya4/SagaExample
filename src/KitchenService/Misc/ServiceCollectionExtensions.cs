using KitchenService.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace KitchenService.Misc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, string conn)
    {
        services.AddDbContextFactory<AppDbContext>((serviceProvider, optionsBuilder) =>
        {
            optionsBuilder.UseNpgsql(conn, builder => builder.EnableRetryOnFailure());
        });

        return services;
    }
}