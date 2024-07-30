using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.UserAggregate;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Repositories;


public class UserRepository : IUserRepository
{
    private readonly ShopAppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public UserRepository(ShopAppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task Add(User user, CancellationToken cancellationToken)
    {
        _context.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetUserByClaim(ClaimsPrincipal user, CancellationToken cancellationToken)
    {
        var userId = _userManager.GetUserId(user);
        if(userId is null)
        {
            return null;
        }
        return await GetUserById(Guid.Parse(userId), cancellationToken);
    }

    public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        return  await _context.Users
                        .SingleOrDefaultAsync(e => e.Email == email, cancellationToken);
    }

    public async Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        
        return await _context.Users
                    .FindAsync(UserId.Create(id), cancellationToken);
    }
    
}

