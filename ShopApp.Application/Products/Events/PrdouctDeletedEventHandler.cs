using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.ProductAggregate.Events;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Application.Products.Events;


public class PrdouctDeletedEventHandler : INotificationHandler<ProductDeleted>
{

    private readonly ICategoryRepository _categoryRepository;

    public PrdouctDeletedEventHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(ProductDeleted notification, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository
                .GetById(notification.Product.CategoryId, cancellationToken);
                
        
        category?.RemoveProductId((ProductId)notification.Product.Id);

        
    }
}
