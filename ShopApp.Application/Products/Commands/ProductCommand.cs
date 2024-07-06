using System.Security.Claims;
using ErrorOr;
using MediatR;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate;

namespace ShopApp.Application.Products.Commands;


public record ProductCommand(
    string Name,
    int Quantity,
    Guid CategoryId,
    float Price,
    string Description,
    ClaimsPrincipal User

) : IRequest<ErrorOr<Product>>;

