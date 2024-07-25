using MediatR;
using ShopApp.Contracts.Categories;

namespace ShopApp.Application.Categories.Queries;


public record CategoryListQuery() : IRequest<IEnumerable<CategoryResponse>>;
