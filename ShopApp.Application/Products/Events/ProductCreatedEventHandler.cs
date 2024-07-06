using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.ProductAggregate.Events;

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
        await Task.CompletedTask;
    }
}