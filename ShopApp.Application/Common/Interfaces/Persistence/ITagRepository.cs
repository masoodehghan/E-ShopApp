using ShopApp.Domain.TagAggregate;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface ITagRepository
{
    Task Add(Tag tag, CancellationToken cancellationToken);
}
