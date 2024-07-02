using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.TagAggregate.ValueObjects;


public class TagId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private TagId(Guid value)
    {
        Value = value;
    }

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

