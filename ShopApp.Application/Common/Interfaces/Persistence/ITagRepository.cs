using ShopApp.Domain.TagAggregate;
using ShopApp.Domain.TagAggregate.ValueObjects;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface ITagRepository
{
    Task Add(Tag tag, CancellationToken cancellationToken);
    Task<Tag?> GetById(TagId id, CancellationToken cancellationToken);
}
