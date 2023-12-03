using KitchenService.Misc;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace KitchenService.Tests;

[TestClass]
public class MiscTests
{
    [TestMethod]
    public void GetConn_ConnProvided_ParseConn()
    {
        var config = new ConfigurationManager();
        config.AddInMemoryCollection(new Dictionary<string, string?>()
        {
            ["ConnectionString:Host"] = "localhost"
        });

        var builder = new NpgsqlConnectionStringBuilder();

        var conn = config.GetConn();
    }
}