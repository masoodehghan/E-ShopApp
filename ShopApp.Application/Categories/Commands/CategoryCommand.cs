using ErrorOr;
using MediatR;
using ShopApp.Domain.CategoryAggregate;

namespace ShopApp.Application.Categories.Commands;


public record CategoryCommand(
    string Name
) : IRequest<ErrorOr<Category>>;
