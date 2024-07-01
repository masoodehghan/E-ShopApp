using ShopApp.Domain.Common;
using ShopApp.Domain.OrderAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Domain.OrderAggregate.Entities;


public sealed class OrderItem : Entity<OrderItemId>
{
    public int Quantity { get; private set; } = 1;

    public ProductId ProductId  { get; private set; }
    

}
