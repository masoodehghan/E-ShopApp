using System.Data;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IDapperContext
{
    public IDbConnection ConnectionCreate();
    public IDbConnection ConnectionCreate(string dbConnectionString);

}

