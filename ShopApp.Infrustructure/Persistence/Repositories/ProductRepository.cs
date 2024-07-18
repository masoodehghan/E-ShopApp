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

    public async Task Add(Product product)
    {
        
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product?> GetById(ProductId id)
    {
        return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task Update(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

}
