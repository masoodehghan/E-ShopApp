using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.UserAggregate.ValueObjects;


public class UserId : AggregateRootId<Guid>
{
    
    public override Guid Value { get; protected set; }
    private UserId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new(value);
    }

}
