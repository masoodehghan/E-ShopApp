

using ShopApp.Domain.Common;

namespace ShopApp.Domain.BuyerAggregate.ValueObjects;


public class BuyerId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private BuyerId(Guid value)
    {
        Value = value;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static BuyerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static BuyerId Create(Guid value)
    {
        return new(value);
    }

}

