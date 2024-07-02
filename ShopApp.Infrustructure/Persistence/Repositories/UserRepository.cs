using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.UserAggregate;

namespace ShopApp.Infrustructure.Persistence.Repositories;


public class UserRepository : IUserRepository
{
    private readonly ShopAppDbContext _context;

    public UserRepository(ShopAppDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return  await _context.Users.SingleOrDefaultAsync();
    }
}

