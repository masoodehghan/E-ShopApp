using ShopApp.Domain.Common;

namespace ShopApp.Domain.TagAggregate.ValueObjects;


public class TagId : EntityId
{
    
    private TagId(Guid value) : base(value)
    { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static TagId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static TagId Create(Guid value)
    {
        return new(value);
    }

}

