using ShopApp.Domain.Common;

namespace ShopApp.Domain.CategoryAggregate.ValueObjects;


public class CategoryId : EntityId
{
    
    private CategoryId(Guid value) : base(value)
    { }
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

