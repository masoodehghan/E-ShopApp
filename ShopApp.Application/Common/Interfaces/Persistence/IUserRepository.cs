using ShopApp.Domain.UserAggregate;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IUserRepository
{

    Task Add(User user);

    Task<User?> GetUserByEmail(string email);

    Task<User?> GetUserById(Guid id);
}

