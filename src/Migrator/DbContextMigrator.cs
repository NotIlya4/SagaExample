using Microsoft.EntityFrameworkCore;

namespace Migrator;

public class DbContextMigrator
{
    private readonly ILogger<DbContextMigrator> _logger;

    public DbContextMigrator(ILogger<DbContextMigrator> logger)
    {
        _logger = logger;
    }

    public async Task Migrate(IEnumerable<DbContext> dbContexts)
    {
        _logger.LogInformation(
            "Start migrating {DbContextNumber} DbContexts: {DbContexts}", 
            dbContexts.Count(), 
            dbContexts.Select(x => x.GetType().Name));

        foreach (var dbContext in dbContexts)
        {
            _logger.LogInformation("Start migration for {DbContextName}", dbContext.GetType().Name);
            
            var pendMigrations = await dbContext.Database.GetPendingMigrationsAsync();
            
            if (pendMigrations.Count() == 0)
            {
                _logger.LogInformation("No pending migrations found");
            }
            else
            {
                _logger.LogInformation(
                    "Applying {MigrationsCount} migrations: {Migrations}", 
                    pendMigrations.Count(),
                    pendMigrations);
            }
            
            await dbContext.Database.MigrateAsync();
            
            _logger.LogInformation("Migrations for {DbContextName} were applied", dbContext.GetType().Name);
        }
        
        _logger.LogInformation("Migration finished");
    }
}