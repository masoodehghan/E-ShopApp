using System.Security.Claims;
using Mapster;
using ShopApp.Application.Categories.Commands;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Application.Products.Commands;
using ShopApp.Application.Products.Queries;
using ShopApp.Contracts.Products;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate;

namespace ShopApp.Api.Common.Mapping;


public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(ProductCreateRequest, ClaimsPrincipal), ProductCommand>()
                    .Map(dest => dest.User, src => src.Item2)
                    .Map(dest => dest, src => src.Item1)
                    .Map(dest => dest.Description, src => src.Item1.Description); 
        
        config.NewConfig<Product, ProductResponse>()
                .Map(dest => dest.ProductId, src => src.Id.Value.ToString())
                .Map(dest => dest.Category, src => src.CategoryId);

        config.NewConfig<(ProductUpdateRequest, ClaimsPrincipal), ProductUpdateQuery>()
                    .Map(dest => dest.User, src => src.Item2)
                    .Map(dest => dest, src => src.Item1);

        config.NewConfig<(ProductDeleteRequest, ClaimsPrincipal), ProductDeleteQuery>()
                        .Map(dest => dest.User, src => src.Item2)
                        .Map(dest => dest.Id, src => src.Item1.Id);
    }
}
