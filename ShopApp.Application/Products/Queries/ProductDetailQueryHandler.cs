using System.Data;
using System.Data.Common;
using Dapper;
using ErrorOr;
using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Contracts.Categories;
using ShopApp.Contracts.Products;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.ProductAggregate;

namespace ShopApp.Application.Products.Queries;



public class ProductDetailQueryHandler : IRequestHandler<ProductDetailQuery, ErrorOr<ProductResponse>>
{
    private readonly IDapperContext _dapper;

    public ProductDetailQueryHandler(IDapperContext dapper)
    {
        _dapper = dapper;
    }

    public async Task<ErrorOr<ProductResponse>> Handle(ProductDetailQuery request, CancellationToken cancellationToken)
    {
        using(IDbConnection connection = _dapper.ConnectionCreate())
        {
        


        var parameter = new { ProductId = request.ProductId };
        var sql = @"SELECT p.CategoryId, p.Name, p.ProductId, p.Name, p.Price,
                    c.CategoryId, c.Name FROM products AS p
                    INNER JOIN Categories AS c ON p.CategoryId == c.CategoryId
                    WHERE p.ProductId == @ProductId
                    LIMIT 1";
        
        var product = await connection.
                    QueryAsync<ProductResponse, CategoryResponse, ProductResponse>(
                    sql,
                    (product, category) => {
                        product.Category = category;
                        return product;
                    },
                    splitOn: "CategoryId",
                    param: parameter);

        int ProductCount = product.Count();
        if(ProductCount == 0 || ProductCount > 1)
        {
            return Errors.Product.NotFound; 
        }

        return product.First();
        
        }
    }  
}

