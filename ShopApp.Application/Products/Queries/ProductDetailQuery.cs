using ErrorOr;
using MediatR;
using ShopApp.Contracts.Products;

namespace ShopApp.Application.Products.Queries;


public record ProductDetailQuery(string ProductId) : IRequest<ErrorOr<ProductResponse>>;
