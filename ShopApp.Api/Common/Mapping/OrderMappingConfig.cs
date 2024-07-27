using System.Security.Claims;
using Mapster;
using ShopApp.Application.Orders.Commands;
using ShopApp.Contracts.Orders;
using ShopApp.Domain.OrderAggregate;
using ShopApp.Domain.OrderAggregate.Entities;
using ShopApp.Domain.OrderAggregate.ValueObjects;

namespace ShopApp.Api.Common.Mapping;


public class OrderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(OrderCreateRequest, ClaimsPrincipal), OrderCommand>()
                .Map(dest => dest.User, src => src.Item2)
                .Map(dest => dest, src => src.Item1);

        config.NewConfig<Order, OrderResponse>()
                .Map(dest => dest.OrderId, src => src.Id.Value.ToString())
                .Map(dest => dest.OrderItems, src => src.OrderItems);

        config.NewConfig<OrderItem, OrderItemResponse>()
                .Map(dest => dest.ProductId, src => src.ProductId.Value.ToString());
        
        config.NewConfig<Address, AddressResponse>();
    }
}
