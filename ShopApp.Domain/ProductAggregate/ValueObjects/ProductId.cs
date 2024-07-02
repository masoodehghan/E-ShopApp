using ShopApp.Domain.Common;

namespace ShopApp.Domain.ProductAggregate.ValueObjects;


public class ProductId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private ProductId(Guid value)
    {
        Value = value;
    }

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
