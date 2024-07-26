using ErrorOr;
using MediatR;
using ShopApp.Domain.OrderAggregate;

namespace ShopApp.Application.Orders.Commands;


public record OrderCommand(
    OrderItemCommand OrderItem,
    int Number,
    AddressCommand Address
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
