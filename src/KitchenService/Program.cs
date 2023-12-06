using KitchenService.Misc;
using Newtonsoft.Json.Converters;
using Shared.Misc;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddKitchenServices();
services.AddKitchenDbContext(config.GetPostgresConn());

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();