using ShopApp.Domain.OrderAggregate;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IOrderRepository
{
    public Task Add(Order order, CancellationToken cancellationToken);
}
