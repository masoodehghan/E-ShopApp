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

    public async Task Add(Buyer buyer)
    {
        await _context.AddAsync(buyer);
        await _context.SaveChangesAsync();
    }

    public async Task<Buyer> GetByUserId(UserId userId)
    {
        return await _context.Buyers.SingleAsync(s => s.UserId == userId);
    }
}
