using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.Common;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Domain.CategoryAggregate;


public sealed class Catgory : AggregateRoot<CategoryId>
{
    public string Name { get; private set; }
    private readonly List<ProductId> _productIds = new();
    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();

    public Catgory(CategoryId id, string name, List<ProductId> productIds)
    {
        Name = name;
        _productIds = productIds;
    }

    public static Catgory Create(string name, List<ProductId>? productIds)
    {
        return new(CategoryId.CreateUnique(), name, productIds ?? new());
    }

    #pragma warning disable CS8618

    private Catgory()
    { }
    #pragma warning restore CS8618
}
