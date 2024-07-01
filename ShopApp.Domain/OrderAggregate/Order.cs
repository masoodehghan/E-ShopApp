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

    private Order(
        OrderId id,
        int number,
        List<OrderItemId> orderItemIds,
        Address address,
        BuyerId buyerId)
    {
        Number = number;
        _orderItemIds = orderItemIds;
        Address = address;
        BuyerId = buyerId;
    }

    public static Order Create(
        int number,
        List<OrderItemId> orderItemIds,
        Address address,
        BuyerId buyerId
    )
    {
        return new(
            OrderId.CreateUnique(),
            number,
            orderItemIds ?? new(),
            address,
            buyerId
        );
    }

    #pragma warning disable CS8618

    private Order()
    { }
    #pragma warning restore CS8618
}
