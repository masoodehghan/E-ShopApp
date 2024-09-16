using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.TagAggregate;
using ShopApp.Domain.TagAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Repositories;


public class TagRepository : ITagRepository
{
    private readonly ShopAppDbContext _context;

    public TagRepository(ShopAppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Tag tag, CancellationToken cancellationToken)
    {
        await _context.Tags.AddAsync(tag, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Tag?> GetById(TagId id, CancellationToken cancellationToken)
    {
        return await _context.Tags.SingleOrDefaultAsync(
                            f => f.Id == id, cancellationToken
        );
        
    }
}
