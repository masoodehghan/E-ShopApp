using System.Security.Claims;
using Mapster;
using ShopApp.Application.Categories.Commands;
using ShopApp.Contracts.Categories;
using ShopApp.Domain.CategoryAggregate;

namespace ShopApp.Api.Common.Mapping;


public class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CategoryRequest, ClaimsPrincipal), CategoryCommand>()
                .Map(dest => dest.User, src => src.Item2)
                .Map(dest => dest, src => src.Item1);
            
        config.NewConfig<Category, CategoryResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString())
                .Map(dest => dest.ProductIds, src => src.ProductIds.Select(g => g.Value.ToString()).ToList());
    }
}
