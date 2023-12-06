using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Shared.Misc;

public static class ServiceCollectionExtensions
{
    public static string GetPostgresConn(this IConfiguration config, string section = "ConnectionString")
    {
        var builder = new NpgsqlConnectionStringBuilder();

        var values = config.GetSection(section).GetChildren();
        foreach (var value in values)
        {
            builder[value.Key] = value.Value;
        }

        return builder.ConnectionString;
    }
}