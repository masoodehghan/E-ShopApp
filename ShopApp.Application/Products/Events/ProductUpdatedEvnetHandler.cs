using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.ProductAggregate.Events;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Application.Products.Events;


public class ProductUpdatedEvnetHandler : INotificationHandler<ProductUpdated>
{
    private readonly ICategoryRepository _categoryRepository;

    public ProductUpdatedEvnetHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(ProductUpdated notification, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository
                    .GetById(notification.Product.CategoryId, cancellationToken); 
        if (category is null)
        {
            CancellationTokenSource source = new();
            source.Cancel();
            await _categoryRepository.CancelOperation(source.Token);
        }
        else
        {
            category.AddProductId(ProductId.Create(notification.Product.Id.Value));
        }
    }
}