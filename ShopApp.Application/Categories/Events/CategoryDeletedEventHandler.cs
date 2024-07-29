using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.CategoryAggregate.Events;
using ShopApp.Domain.ProductAggregate.Events;

namespace ShopApp.Application.Categories.Events;


public class CategoryDeletedEventHandler : INotificationHandler<CategoryDeleted>
{
    private readonly IProductRepository _productRepository;

    public CategoryDeletedEventHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(CategoryDeleted notification, CancellationToken cancellationToken)
    {
        foreach(var productId in notification.Category.ProductIds)
        {
            var product = await _productRepository.GetById(productId, cancellationToken);
            
            if(product is null)
            {
                CancellationTokenSource source = new();
                source.Cancel();
                await _productRepository.CancelOperations(source.Token);
                
            }
            else
            {
                await _productRepository.Delete(
                        product,
                        cancellationToken);
                product.AddDomainEvents(new ProductDeleted(product));
                
            }
        }
    }
}
