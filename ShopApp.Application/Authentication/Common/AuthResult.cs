using ShopApp.Domain.UserAggregate;

namespace ShopApp.Application.Authentication.Common;


public record AuthResult(
            User User,
            string Token
);
