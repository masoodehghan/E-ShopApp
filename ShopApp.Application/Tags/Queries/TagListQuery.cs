using MediatR;
using ShopApp.Contracts.Tags;

namespace ShopApp.Application.Tags.Queries;


public record TagListQuery() : IRequest<IEnumerable<TagResponse>>;
