using ShopApp.Domain.BuyerAggregate.ValueObjects;
using ShopApp.Domain.Common.Models;
using ShopApp.Domain.OrderAggregate.ValueObjects;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Domain.BuyerAggregate;


public sealed class Buyer : AggregateRoot<BuyerId, Guid>
{
    public UserId UserId { get; private set; }
    private readonly List<OrderId> _orderIds = new();
    public IReadOnlyList<OrderId> OrderIds => _orderIds.AsReadOnly();

    private Buyer(BuyerId id, UserId userId, List<OrderId> orderIds)
    {
        Id = id;
        UserId = userId;
        _orderIds = orderIds;
    }

    public static Buyer Create(UserId userId, List<OrderId>? orderIds = null)
    {
        return new(BuyerId.CreateUnique(), userId, orderIds ?? new());
    }

    #pragma warning disable CS8618

    private Buyer()
    { }
    #pragma warning restore CS8618
}
