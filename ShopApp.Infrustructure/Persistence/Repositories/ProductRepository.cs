using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.ProductAggregate;

namespace ShopApp.Infrustructure.Persistence.Repositories;


public class ProductRepository : IProductRepository
{
    private readonly ShopAppDbContext _context;
public ProductRepository(ShopAppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}
