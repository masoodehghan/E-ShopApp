using System.Security.Claims;
using ErrorOr;
using MediatR;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate;

namespace ShopApp.Application.Products.Queries;


public record ProductUpdateQuery(
    Guid Id,
    string Name,
    float Price,
    int Quantity,
    string Description,
    Guid? CategoryId,
    ClaimsPrincipal User
) : IRequest<ErrorOr<Product>>;
