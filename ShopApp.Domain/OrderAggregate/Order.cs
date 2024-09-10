using ShopApp.Domain.BuyerAggregate.ValueObjects;
using ShopApp.Domain.Common.Models;
using ShopApp.Domain.OrderAggregate.Entities;
using ShopApp.Domain.OrderAggregate.Enums;
using ShopApp.Domain.OrderAggregate.Evnents;
using ShopApp.Domain.OrderAggregate.ValueObjects;

namespace ShopApp.Domain.OrderAggregate;


public sealed class Order : AggregateRoot<OrderId, Guid>
{
    public int Number { get; private set; }

    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public Address Address { get; private set; }
    
    public BuyerId BuyerId { get; private set; }

    public float? TotalPrice { get; private set; }

    public OrderStatus? OrderStatus { get; private set; } = null;

    private Order(
        OrderId id,
        int number,
        List<OrderItem> orderItems,
        Address address,
        BuyerId buyerId,
        OrderStatus orderStatus = Enums.OrderStatus.UnPaid)
    {
        Id = id;
        Number = number;
        _orderItems = orderItems;
        Address = address;
        BuyerId = buyerId;
        OrderStatus = orderStatus;
    }

    public static Order Create(
        int number,
        Address address,
        BuyerId buyerId,
        List<OrderItem> orderItems
    )
    {
        Order order =  new(
            OrderId.CreateUnique(),
            number,
            orderItems ?? new(),
            address,
            buyerId
        );

        order.AddDomainEvents(new OrderCreated(order));

        return order;
    }

    public void SetTotalPrice(float totalPrice)
    {
        TotalPrice = totalPrice;
    }

    #pragma warning disable CS8618

    private Order()
    { }
    #pragma warning restore CS8618
}
