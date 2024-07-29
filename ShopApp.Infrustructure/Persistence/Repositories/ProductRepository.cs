using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Repositories;


public class ProductRepository : IProductRepository
{
    private readonly ShopAppDbContext _context;
    
    public ProductRepository(ShopAppDbContext context)
        {
            _context = context;
        }

    public async Task Add(Product product, CancellationToken cancellationToken)
    {
        
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Product?> GetById(ProductId id, CancellationToken cancellationToken)
    {
        return await _context.Products
                        .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    

    public async Task Update(Product product, CancellationToken cancellationToken)
    {
        _context.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIds(List<ProductId> productIds, CancellationToken cancellationToken)
    {
        
        var product =  await _context
                        .Products
                        .Where(s => _context.Products.Contains(s))
                        .FirstAsync(cancellationToken);
                        
        return product;
    }

    public async Task CancelOperations(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
