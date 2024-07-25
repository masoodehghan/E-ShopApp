using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.BuyerAggregate;

namespace ShopApp.Infrustructure.Persistence.Repositories;


public class BuyerRepository : IBuyerRepository
{

    private readonly ShopAppDbContext _context;

    public BuyerRepository(ShopAppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Buyer buyer)
    {
        await _context.AddAsync(buyer);
        await _context.SaveChangesAsync();
    }
}
