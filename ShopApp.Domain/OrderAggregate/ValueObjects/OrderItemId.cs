using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.OrderAggregate.ValueObjects;


public class OrderItemId : EntityId
{
    
    private OrderItemId(Guid value) : base(value)
    { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static OrderItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static OrderItemId Create(Guid value)
    {
        return new(value);
    }

}
