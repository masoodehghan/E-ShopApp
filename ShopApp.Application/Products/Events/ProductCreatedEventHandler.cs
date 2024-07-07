using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.ProductAggregate.Events;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Application.Products.Events;

public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
{

    private readonly ICategoryRepository _categoryRepository;

    public ProductCreatedEventHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetById(notification.Prodcut.CategoryId); 
        if (category is null)
        {
            return;
        }

        category.AddProductId(ProductId.Create(notification.Prodcut.Id.Value));
    }
}