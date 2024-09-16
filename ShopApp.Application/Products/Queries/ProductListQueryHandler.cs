using System.Data;
using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Contracts.Categories;
using ShopApp.Contracts.Products;
using Dapper;
using ShopApp.Contracts.Tags;

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
                        c.CategoryId, c.Name,
                        t.TagId, t.Name
                        FROM products AS p
                        INNER JOIN Categories AS c ON c.CategoryId == p.CategoryId
                        LEFT JOIN ProductTagIds AS pti ON pti.ProductId == p.ProductId
                        LEFT JOIN Tags AS t ON pti.TagId == t.TagId
                        LIMIT 100";
                
            var products = await 
                        connection.QueryAsync<
                                ProductResponse,
                                CategoryResponse,
                                TagResponse,
                                ProductResponse>
                        (
                        sql: query,
                        (product, category, tag) => 
                        { 
                            product.Category = category;
                            product.Tags.Add(tag);
                            return product;
                        },
                        splitOn: "CategoryId, TagId");
            
            products = products.GroupBy(s => s.ProductId).
                    Select(f => {
                        var product = f.First();
                        product.Tags = f.Select(s => s.Tags.First()).ToList();
                        return product;
                    });
                        

            return products.ToList();

        }
    }
}
