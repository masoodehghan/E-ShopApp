using System.Security.Claims;
using ErrorOr;
using MediatR;
using ShopApp.Domain.CategoryAggregate;

namespace ShopApp.Application.Categories.Queries;

public record CategoryUpdateQuery(
    string CategoryId,
    string Name,
    ClaimsPrincipal User
) : IRequest<ErrorOr<Category>>;
