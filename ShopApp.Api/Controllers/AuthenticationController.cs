using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Authentication.Commands.Register;
using ShopApp.Application.Authentication.Common;
using ShopApp.Contracts.Authentication;
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


    [HttpPost]
    [Route("register")]
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

    [HttpPost]
    [Route("secret")]
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
}

