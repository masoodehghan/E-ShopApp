using System.Security.Claims;
using ErrorOr;
using MediatR;

namespace ShopApp.Application.Categories.Queries;


public record CategoryDeleteQuery(
    string CategoryId,
    ClaimsPrincipal User
) : IRequest<ErrorOr<bool>>;
