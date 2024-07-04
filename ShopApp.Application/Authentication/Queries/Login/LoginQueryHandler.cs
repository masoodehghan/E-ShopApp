using ShopApp.Application.Common.Interfaces.Authentication;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Application.Authentication.Common;
using ErrorOr;
using MediatR;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.UserAggregate;

namespace ShopApp.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthResult>> Handle(
        LoginQuery command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (await _userRepository.GetUserByEmail(command.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.HashedPassword != command.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }


            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthResult(user, token);
    }
}

