using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Authentication.Commands.Register;
using ShopApp.Application.Authentication.Common;
using ShopApp.Application.Authentication.Queries.Login;
using ShopApp.Contracts.Authentication;
using ShopApp.Domain.Common.Errors;
using ShopApp.Infrustructure.Authentication;

namespace ShopApp.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    private readonly SuperUserSecret _secret;

    public AuthenticationController(IMapper mapper, ISender mediatr, SuperUserSecret secret)
    {
        _mapper = mapper;
        _mediator = mediatr;
        _secret = secret;
    }


    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthResult> result = await _mediator.Send(command);

        return result.Match(
            authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("secret")]
    [AllowAnonymous ]
    public async Task<IActionResult> CreateSuperUser(CreateSuperUserRequest request)
    {
        
        if(request.Secret != _secret.Secret)
        {
            return Problem("invalid secret");
        }

        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthResult> result = await _mediator.Send(command);

        return result.Match(
            authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var query = _mapper.Map<LoginQuery>(request);
        var AuthResult = await _mediator.Send(query);

        if (AuthResult.IsError && AuthResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: AuthResult.FirstError.Description
                );
        }

        return AuthResult.Match(
            authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
            errors => Problem(errors)
        );
    }
}

