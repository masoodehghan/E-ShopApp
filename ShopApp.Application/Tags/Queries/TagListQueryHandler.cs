using System.Data;
using Dapper;
using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Contracts.Tags;

namespace ShopApp.Application.Tags.Queries;

public class TagListQueryHandler : IRequestHandler<TagListQuery, IEnumerable<TagResponse>>
{
    private readonly IDapperContext _dapperContext;

    public TagListQueryHandler(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<TagResponse>> Handle(TagListQuery request, CancellationToken cancellationToken)
    {
        using(IDbConnection connection = _dapperContext.ConnectionCreate())
        {
            var sql = @"SELECT * FROM Tags";

            var tags = await connection.QueryAsync<TagResponse>(sql);

            return tags;

        }
    }
}
