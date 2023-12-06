using KitchenService.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Migrator;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var fastFactory = new FastContextFactory(config);
var migrator = new DbContextMigrator(LoggerStatic.CreateLogger<DbContextMigrator>());

var kitchenContext = fastFactory.CreateContext("KitchenConnectionString", o => new KitchenDbContext(o));

await migrator.Migrate(new [] { kitchenContext });