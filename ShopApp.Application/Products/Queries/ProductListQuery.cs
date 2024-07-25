using MediatR;
using ShopApp.Contracts.Products;

namespace ShopApp.Application.Products.Queries;


public record ProductListQuery(): IRequest<IEnumerable<ProductResponse>>;
