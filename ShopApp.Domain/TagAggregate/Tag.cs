using ShopApp.Domain.Common;
using ShopApp.Domain.ProductAggregate.ValueObjects;
using ShopApp.Domain.TagAggregate.ValueObjects;

namespace ShopApp.Domain.TagAggregate;


public sealed class Tag : AggregateRoot<TagId>
{
    public string Name { get; private set; }
    private readonly List<ProductId> _productIds = new();
    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();
}
