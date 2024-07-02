using ShopApp.Domain.UserAggregate;

namespace ShopApp.Application.Common.Interfaces.Authentication;
 
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

