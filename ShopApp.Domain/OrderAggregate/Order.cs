using ShopApp.Domain.BuyerAggregate.ValueObjects;
using ShopApp.Domain.Common;
using ShopApp.Domain.OrderAggregate.ValueObjects;

namespace ShopApp.Domain.OrderAggregate;


public sealed class Order : AggregateRoot<OrderId>
{
    public int Number { get; private set; }
    
    private readonly List<OrderItemId> _orderItemIds = new();
    public IReadOnlyList<OrderItemId> OrderItemIds => _orderItemIds.AsReadOnly();

    public Address Address { get; private set; }
    
    public BuyerId BuyerId { get; private set; } 

}
