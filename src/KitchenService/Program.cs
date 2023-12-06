using KitchenService.Misc;
using Shared.Misc;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddKitchenServices();
services.AddKitchenDbContext(config.GetPostgresConn());

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();