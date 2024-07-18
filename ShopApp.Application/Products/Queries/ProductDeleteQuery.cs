using System.Security.Claims;
using ErrorOr;
using MediatR;

namespace ShopApp.Application.Products.Queries;


public record ProductDeleteQuery(
    string Id,
    ClaimsPrincipal User
) : IRequest<ErrorOr<bool>>;
