using Mapster;
using ShopApp.Application.Authentication.Commands.Register;
using ShopApp.Application.Authentication.Common;
using ShopApp.Contracts.Authentication;
using ShopApp.Domain.UserAggregate.Enums;

namespace ShopApp.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<CreateSuperUserRequest, RegisterCommand>()
                .Map(dest => dest.Role, src => Roles.SuperAdmin);
        config.NewConfig<AuthResult, AuthResponse>()
                    .Map(dest => dest, src => src.User)
                    .Map(dest => dest.Id, src => src.User.Id.Value.ToString());
    }
}