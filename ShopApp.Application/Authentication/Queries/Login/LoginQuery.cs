using ShopApp.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace ShopApp.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthResult>>;

