using System.Data;
using Microsoft.EntityFrameworkCore;

namespace KitchenService.EntityFramework;

public static class DbContextExtensions
{
    public static async Task<TReturn> WithRetry<TReturn>(
        this IDbContextFactory<AppDbContext> factory, 
        Func<AppDbContext, Task<TReturn>> func,
        IsolationLevel isolationLevel)
    {
        var context = await factory.CreateDbContextAsync();
        var strategy = context.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            await using var localContext = await factory.CreateDbContextAsync();
            await using var transaction = await localContext.Database.BeginTransactionAsync(isolationLevel);

            var result = await func(localContext);

            await transaction.CommitAsync();

            return result;
        });
    }
}