using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.Common;
using ShopApp.Domain.OrderAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate.ValueObjects;
using ShopApp.Domain.TagAggregate.ValueObjects;

namespace ShopApp.Domain.ProductAggregate;


public sealed class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; }
    public float Price { get; private set; }
    public int Quantity { get; private set; } = 1;
    public string? Description { get; private set; }
    
    public CategoryId CategoryId { get; private set; }
    
    private readonly List<OrderItemId> _orderItemIds = new();
    public IReadOnlyList<OrderItemId> OrderItemIds => _orderItemIds.AsReadOnly();

    private readonly List<TagId> _tagIds = new();
    public IReadOnlyList<TagId> TagIds => _tagIds.AsReadOnly();


}
