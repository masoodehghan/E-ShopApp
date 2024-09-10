using System.Security.Claims;
using ErrorOr;
using MediatR;
using ShopApp.Domain.TagAggregate;

namespace ShopApp.Application.Tags.Commands;


public record TagCreateCommand(
    string Name,
    ClaimsPrincipal User
) : IRequest<ErrorOr<Tag>>;

