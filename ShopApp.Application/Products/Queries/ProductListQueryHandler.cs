using System.Data;
using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Contracts.Categories;
using ShopApp.Contracts.Products;
using Dapper;

namespace ShopApp.Application.Products.Queries;

public class ProductListQueryHandler : IRequestHandler<ProductListQuery, IEnumerable<ProductResponse>>
{
    private readonly IDapperContext _dapperContext;

    public ProductListQueryHandler(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<ProductResponse>> Handle(ProductListQuery request, CancellationToken cancellationToken)
    {
        using(IDbConnection connection = _dapperContext.ConnectionCreate() )
        {
            var query = @"SELECT p.Name, p.ProductId, p.IsAvailable,
                        p.Description, p.Quantity, p.Price,
                        c.CategoryId, c.Name
                        FROM products AS p
                        INNER JOIN Categories AS c ON c.CategoryId == p.CategoryId
                        LIMIT 100";
                
            var products = await 
                        connection.QueryAsync<ProductResponse, CategoryResponse, ProductResponse>
                        (
                        sql: query,
                        (product, category) => 
                        { 
                            product.Category = category;

                            return product;
                        },
                        splitOn: "CategoryId");
            
            return products;

        }
    }
}
