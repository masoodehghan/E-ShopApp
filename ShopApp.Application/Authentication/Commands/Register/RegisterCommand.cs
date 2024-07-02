namespace ShopApp.Application.Authentication.Commands.Register;

using ErrorOr;
using MediatR;
using ShopApp.Application.Authentication.Common;

public record RegisterCommand(
    string FirstName,
    string Username,
    string LastName,
    string Email,
    string Password,
    long? PhoneNumber
) : IRequest<ErrorOr<AuthResult>>;

