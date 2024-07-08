using System.Security.Claims;
using Mapster;
using ShopApp.Application.Categories.Commands;
using ShopApp.Application.Categories.Queries;
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


        config.NewConfig<(CategoryUpdateRequest, ClaimsPrincipal), CategoryUpdateQuery>()
                        .Map(dest => dest.User, src => src.Item2)
                        .Map(dest => dest.CategoryId, src => src.Item1.Id)
                        .Map(dest => dest.Name, src => src.Item1.Name);
        
        }
}
