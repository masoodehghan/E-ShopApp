using ShopApp.Domain.BuyerAggregate.ValueObjects;
using ShopApp.Domain.Common.Models;
using ShopApp.Domain.OrderAggregate.Entities;
using ShopApp.Domain.OrderAggregate.ValueObjects;

namespace ShopApp.Domain.OrderAggregate;


public sealed class Order : AggregateRoot<OrderId, Guid>
{
    public int Number { get; private set; }

    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyList<OrderItem> OrderItemIds => _orderItems.AsReadOnly();

    public Address Address { get; private set; }
    
    public BuyerId BuyerId { get; private set; }

    private Order(
        OrderId id,
        int number,
        List<OrderItem> orderItems,
        Address address,
        BuyerId buyerId)
    {
        Number = number;
        _orderItems = orderItems;
        Address = address;
        BuyerId = buyerId;
    }

    public static Order Create(
        int number,
        List<OrderItem> orderItems,
        Address address,
        BuyerId buyerId
    )
    {
        return new(
            OrderId.CreateUnique(),
            number,
            orderItems ?? new(),
            address,
            buyerId
        );
    }

    #pragma warning disable CS8618

    private Order()
    { }
    #pragma warning restore CS8618
}
