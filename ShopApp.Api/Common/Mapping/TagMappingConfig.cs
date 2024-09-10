using System.Security.Claims;
using Mapster;
using ShopApp.Application.Tags.Commands;
using ShopApp.Contracts.Tags;
using ShopApp.Domain.TagAggregate;

namespace ShopApp.Api.Common.Mapping;


public class TagMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(TagCreateRequest, ClaimsPrincipal), TagCreateCommand>()
                .Map(dest => dest.User, src => src.Item2)
                .Map(dest => dest, src => src.Item1);

        config.NewConfig<Tag, TagResponse>()
                .Map(dest => dest.TagId, src => src.Id.Value.ToString());
    }
}
