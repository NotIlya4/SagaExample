using KitchenService.Misc;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddAppDbContext(config.GetConn());

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();