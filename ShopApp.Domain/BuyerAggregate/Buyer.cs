using ShopApp.Domain.BuyerAggregate.ValueObjects;
using ShopApp.Domain.Common;
using ShopApp.Domain.OrderAggregate.ValueObjects;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Domain.BuyerAggregate;


public sealed class Buyer : AggregateRoot<BuyerId>
{
    public UserId UserId { get; private set; }
    private readonly List<OrderId> _orderIds = new();
    public IReadOnlyList<OrderId> OrderIds => _orderIds.AsReadOnly();
}
