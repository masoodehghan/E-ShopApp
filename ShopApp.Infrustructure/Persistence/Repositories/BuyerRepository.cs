using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.BuyerAggregate;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Repositories;


public class BuyerRepository : IBuyerRepository
{

    private readonly ShopAppDbContext _context;

    public BuyerRepository(ShopAppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Buyer buyer, CancellationToken cancellationToken)
    {
        await _context.AddAsync(buyer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Buyer> GetByUserId(UserId userId, CancellationToken cancellationToken)
    {
        return await _context.Buyers.SingleAsync(s => s.UserId == userId, cancellationToken);
    }
}
