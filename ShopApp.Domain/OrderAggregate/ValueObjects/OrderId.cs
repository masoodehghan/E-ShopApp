using ShopApp.Domain.Common;

namespace ShopApp.Domain.OrderAggregate.ValueObjects;


public class OrderId : EntityId
{
    
    private OrderId(Guid value) : base(value)
    { }
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
