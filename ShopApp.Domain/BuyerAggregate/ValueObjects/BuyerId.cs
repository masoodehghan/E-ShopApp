

using ShopApp.Domain.Common;

namespace ShopApp.Domain.BuyerAggregate.ValueObjects;


public class BuyerId : EntityId
{
    
    private BuyerId(Guid value) : base(value)
    { }
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

