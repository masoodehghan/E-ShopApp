using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.OrderAggregate.Evnents;


public record OrderCreated(
    Order Order
) : IDomainEvent;