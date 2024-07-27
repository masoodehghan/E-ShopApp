using ShopApp.Domain.Common.Models;
using ShopApp.Domain.OrderAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Domain.OrderAggregate.Entities;


public sealed class OrderItem : Entity<OrderItemId>
{
    public int Quantity { get; private set; } = 1;

    public ProductId ProductId  { get; private set; }

    private OrderItem(OrderItemId id, int quantity, ProductId productId)
    {
        Id = id;
        Quantity = quantity;
        ProductId = productId;
    }

    public static OrderItem Create(int quantity, ProductId productId)
    {
        return new(OrderItemId.CreateUnique(), quantity, productId);
    }

    #pragma warning disable CS8618

    private OrderItem()
    { }
    #pragma warning restore CS8618
}
