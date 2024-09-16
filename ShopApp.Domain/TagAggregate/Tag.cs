using ShopApp.Domain.Common.Models;
using ShopApp.Domain.ProductAggregate.ValueObjects;
using ShopApp.Domain.TagAggregate.ValueObjects;

namespace ShopApp.Domain.TagAggregate;


public sealed class Tag : AggregateRoot<TagId, Guid>
{
    public string Name { get; private set; }

    private readonly List<ProductId> _productIds = new();
    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();


    private Tag(TagId id, string name, List<ProductId> productIds)
    {
        Id = id;
        Name = name;
        _productIds = productIds;
    }


    public static Tag Create(string name, List<ProductId>? productIds = null)
    {
        return new(TagId.CreateUnique(), name, productIds ?? new());
    }

    public void AddProductId(ProductId productId)
    {
        if(!_productIds.Contains(productId))
        {
            _productIds.Add(productId);
        }
    }

    #pragma warning disable CS8618
    private Tag()
    { }
    #pragma warning restore CS8618

}
