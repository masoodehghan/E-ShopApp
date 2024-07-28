using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.OrderAggregate;

namespace ShopApp.Infrustructure.Persistence.Repositories;


public class OrderRepository : IOrderRepository
{

    private readonly ShopAppDbContext _context;

    public OrderRepository(ShopAppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
