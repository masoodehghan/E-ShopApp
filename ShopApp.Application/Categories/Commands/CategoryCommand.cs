using System.Security.Claims;
using ErrorOr;
using MediatR;
using ShopApp.Domain.CategoryAggregate;

namespace ShopApp.Application.Categories.Commands;


public record CategoryCommand(
    string Name,
    ClaimsPrincipal User
) : IRequest<ErrorOr<Category>>;
