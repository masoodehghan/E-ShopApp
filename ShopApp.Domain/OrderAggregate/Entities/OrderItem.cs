using ShopApp.Domain.Common.Models;
using ShopApp.Domain.OrderAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Domain.OrderAggregate.Entities;


public sealed class OrderItem : Entity<OrderItemId>
{
    public int Quantity { get; private set; } = 1;

    public ProductId ProductId  { get; private set; }

    public OrderItem(int quantity, ProductId productId)
    {
        Quantity = quantity;
        ProductId = productId;
    }

    public static OrderItem Create(int quantity, ProductId productId)
    {
        return new(quantity, productId);
    }


}
