using System.Data;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;
using ShopApp.Application.Common.Interfaces.Persistence;
using Microsoft.Extensions.Configuration;

namespace ShopApp.Infrustructure.Persistence;


public class DapperContext : IDapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection ConnectionCreate()
    {
        return new SqliteConnection(_configuration.GetConnectionString("defaultConnection"));
    }

    public IDbConnection ConnectionCreate(string dbConnectionString)
    {
        return new SqlConnection(dbConnectionString);
    }
}
