using System.Security.Claims;
using ShopApp.Domain.UserAggregate;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IUserRepository
{

    Task Add(User user, CancellationToken cancellationToken);

    Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);

    Task<User?> GetUserById(Guid id, CancellationToken cancellationToken);

    Task<User?> GetUserByClaim(ClaimsPrincipal user, CancellationToken cancellationToken);
}

