namespace Migrator;

public static class LoggerStatic
{
    public static ILoggerFactory Factory = LoggerFactory.Create(builder =>
    {
        builder.SetMinimumLevel(LogLevel.Information);
        builder.AddConsole();
    });

    public static ILogger<T> CreateLogger<T>()
    {
        return Factory.CreateLogger<T>();
    }
}