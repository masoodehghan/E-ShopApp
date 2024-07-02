using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.CategoryAggregate.ValueObjects;


public class CategoryId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private CategoryId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static CategoryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CategoryId Create(Guid value)
    {
        return new(value);
    }

}

