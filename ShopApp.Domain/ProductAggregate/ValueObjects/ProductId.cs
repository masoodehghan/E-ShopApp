using ShopApp.Domain.Common;

namespace ShopApp.Domain.ProductAggregate.ValueObjects;


public class ProductId : EntityId
{
    
    private ProductId(Guid value) : base(value)
    { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static ProductId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ProductId Create(Guid value)
    {
        return new(value);
    }

}
