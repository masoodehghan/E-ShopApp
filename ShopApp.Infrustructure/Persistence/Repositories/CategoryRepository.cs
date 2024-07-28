using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.CategoryAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Repositories;


public class CategoryRepository : ICategoryRepository
{
    private readonly ShopAppDbContext _context;

    public CategoryRepository(ShopAppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Category category, CancellationToken cancellationToken)
    {
        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetById(CategoryId id)
    {
        return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task Update(Category category)
    {
       _context.Update(category);
       await _context.SaveChangesAsync();

    }
}
