using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.Common;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Domain.CategoryAggregate;


public sealed class Catgory : AggregateRoot<CategoryId>
{
    public string Name { get; private set; }
    
    private readonly List<ProductId> _productIds = new();
    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();
}
