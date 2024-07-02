using BubberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using ShopApp.Application.Authentication.Common;
using ShopApp.Application.Common.Interfaces.Authentication;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.UserAggregate;

namespace ShopApp.Application.Authentication.Commands.Register;


public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthResult>> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        if(await _userRepository.GetUserByEmail(request.Email) is null)
        {
            return Errors.Authentication.DuplicateEmail;
        }

        var user = User.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.Username,
            request.PhoneNumber
        );

        await _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);

    }
}
