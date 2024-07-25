using System.Data;
using MediatR;
using ShopApp.Contracts.Categories;
using Dapper;
using ShopApp.Contracts.Products;
using ShopApp.Application.Common.Interfaces.Persistence;

namespace ShopApp.Application.Categories.Queries;


public class CategoryListQueryHandler : IRequestHandler<CategoryListQuery, IEnumerable<CategoryResponse>>
{

    private readonly IDapperContext _dapperContext;

    public CategoryListQueryHandler(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<IEnumerable<CategoryResponse>> Handle(CategoryListQuery request, CancellationToken cancellationToken)
    {
        using(IDbConnection connection = _dapperContext.ConnectionCreate())
        {
                            // LEFT JOIN CategoryProductIds AS cp ON c.CategoryId == cp.CategoryId

            string query = @"SELECT c.CategoryId, c.Name,
                            p.ProductId, p.Name, p.Quantity, p.Price, p.Description
                            FROM Categories AS c
                            LEFT JOIN products AS p ON p.CategoryId == c.CategoryId
                            ORDER BY c.CategoryId";

            var categories = await 
                        connection.QueryAsync<CategoryResponse, ProductResponse, CategoryResponse>(
                            query,
                            (category, product) => 
                            {
                                category.Products.Add(product);
                                return category;
                            },
                            splitOn: "ProductId");


            categories = categories.GroupBy(f => f.CategoryId).Select(
                s => 
                {
                    var category = s.First();
                    category.Products = s.Select(f => f.Products.First()).ToList();
                    return category;   
                }
            ).ToList();

            return categories;
        }
    }
}
