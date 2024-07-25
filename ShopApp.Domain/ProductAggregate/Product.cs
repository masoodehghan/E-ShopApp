using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.Common.Models;
using ShopApp.Domain.OrderAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate.Events;
using ShopApp.Domain.ProductAggregate.ValueObjects;
using ShopApp.Domain.TagAggregate.ValueObjects;

namespace ShopApp.Domain.ProductAggregate;


public sealed class Product : AggregateRoot<ProductId, Guid>
{
    public string Name { get; private set; }

    public float Price { get; private set; }
    public int Quantity { get; private set; } = 1;
    public string? Description { get; private set; } = string.Empty;
    
    public CategoryId CategoryId { get; private set; }
    
    private readonly List<OrderItemId> _orderItemIds = new();
    public IReadOnlyList<OrderItemId> OrderItemIds => _orderItemIds.AsReadOnly();

    private readonly List<TagId> _tagIds = new();
    public IReadOnlyList<TagId> TagIds => _tagIds.AsReadOnly();

    private Product(
        ProductId id,
        string name,
        float price,
        int quantity,
        string? description,
        CategoryId categoryId,
        List<OrderItemId> orderItemIds,
        List<TagId> tagIds)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        Description = description;
        CategoryId = categoryId;
        _orderItemIds = orderItemIds;
        _tagIds = tagIds;
    }


    public static Product Create(
        string name,
        float price,
        int quantity,
        string? description,
        CategoryId categoryId,
        List<OrderItemId>? orderItemIds = null,
        List<TagId>? tagIds = null)
    {
        Product product = new(
            ProductId.CreateUnique(),
            name,
            price,
            quantity,
            description,
            categoryId,
            orderItemIds ?? new(),
            tagIds ?? new()
        );

        product.AddDomainEvents(new ProductCreated(product));

        return product;
    }


    public static Product Update(
        Product product,
        string? name = null,
        float? price = null,
        CategoryId? categoryId = null,
        int? quantity = null,
        string? description = null)
    
    {
        product.Price = price ?? product.Price;
        product.Name = name ?? product.Name;
        product.CategoryId = categoryId ?? product.CategoryId;
        product.Quantity = quantity ?? product.Quantity;
        product.Description = description ?? product.Description;

        product.AddDomainEvents(new ProductUpdated(product));
        
        return product;
    }

    #pragma warning disable CS8618

    private Product()
    { }
    #pragma warning restore CS8618
}
