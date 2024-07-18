using System.Security.Claims;
using Mapster;
using ShopApp.Application.Categories.Commands;
using ShopApp.Application.Products.Commands;
using ShopApp.Application.Products.Queries;
using ShopApp.Contracts.Products;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate;

namespace ShopApp.Api.Common.Mapping;


public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(ProductCreateRequest, ClaimsPrincipal), ProductCommand>()
                    .Map(dest => dest.User, src => src.Item2)
                    .Map(dest => dest, src => src.Item1); 
        
        config.NewConfig<Product, ProductResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString())
                .Map(dest => dest.CategoryId, src => src.CategoryId.Value.ToString());

        config.NewConfig<(ProductUpdateRequest, ClaimsPrincipal), ProductUpdateQuery>()
                    .Map(dest => dest.User, src => src.Item2)
                    .Map(dest => dest, src => src.Item1);

        config.NewConfig<(ProductDeleteRequest, ClaimsPrincipal), ProductDeleteQuery>()
                        .Map(dest => dest.User, src => src.Item2)
                        .Map(dest => dest.Id, src => src.Item1.Id);
    }
}
