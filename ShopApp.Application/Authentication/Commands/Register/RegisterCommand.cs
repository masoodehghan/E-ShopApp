namespace ShopApp.Application.Authentication.Commands.Register;

using ErrorOr;
using MediatR;
using ShopApp.Application.Authentication.Common;
using ShopApp.Domain.UserAggregate.Enums;

public record RegisterCommand(
    string FirstName,
    string Username,
    string LastName,
    string Email,
    string Password,
    long? PhoneNumber,
    Roles Role = Roles.Buyer
) : IRequest<ErrorOr<AuthResult>>;

