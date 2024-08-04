using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.OrderAggregate.Evnents;

namespace ShopApp.Application.Orders.Events;


public class OrderCreatedEventHandler : INotificationHandler<OrderCreated>
{
    private readonly IProductRepository _productRepository;

    public OrderCreatedEventHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(OrderCreated notification, CancellationToken cancellationToken)
    {
        foreach(var orderItem in notification.Order.OrderItems)
        {
            var product = await _productRepository
                            .GetById(orderItem.ProductId, cancellationToken);
            if(product is null || product.IsAvailable == false)
            {
                CancellationTokenSource source = new();
                source.Cancel();
                await _productRepository.CancelOperations(source.Token);
            }
            else
            {
                product.AddOrderItemId(orderItem.Id);
            }
        }
    }
}
