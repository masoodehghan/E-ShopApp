using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.OrderAggregate.ValueObjects;


public class OrderId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private OrderId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static OrderId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static OrderId Create(Guid value)
    {
        return new(value);
    }

}
