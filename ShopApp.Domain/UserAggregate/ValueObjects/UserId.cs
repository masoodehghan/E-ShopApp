using ShopApp.Domain.Common;

namespace ShopApp.Domain.UserAggregate.ValueObjects;


public class UserId : EntityId
{
    
    private UserId(Guid value) : base(value)
    { }
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
