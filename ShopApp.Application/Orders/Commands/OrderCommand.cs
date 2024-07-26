using System.Security.Claims;
using ErrorOr;
using MediatR;
using ShopApp.Domain.OrderAggregate;

namespace ShopApp.Application.Orders.Commands;


public record OrderCommand(
    List<OrderItemCommand> OrderItems,
    int Number,
    AddressCommand Address,
    ClaimsPrincipal User
) : IRequest<ErrorOr<Order>>;


public record OrderItemCommand(
    string ProductId,
    int Quantity
);


public record AddressCommand(
    string Street,
    string City,
    int Code
);
