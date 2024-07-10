using ShopApp.Domain.CategoryAggregate.Events;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.Common.Models;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Domain.CategoryAggregate;


public sealed class Category : AggregateRoot<CategoryId, Guid>
{
    public string Name { get; private set; }
    private readonly List<ProductId> _productIds = new();
    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();

    public Category(CategoryId id, string name, List<ProductId> productIds)
    {
        Id = id;
        Name = name;
        _productIds = productIds;
    }

    public static Category Create(string name, List<ProductId>? productIds = null)
    {
        Category category =  new(CategoryId.CreateUnique(), name, productIds ?? new());
        category.AddDomainEvents(new CategoryCreated(category));

        return category;
    }

    public static Category Update(Category category, string? name = null)
    {
        category.Name = name ?? category.Name;
        return category;
    }

    public void AddProductIds(List<ProductId> productIds)
    {
        _productIds.AddRange(productIds);
    }

    public void AddProductId(ProductId productId)
    {
        if(!_productIds.Contains(productId))
        {
            _productIds.Add(productId);
        }
        
    }


    #pragma warning disable CS8618

    private Category()
    { }
    #pragma warning restore CS8618
}
