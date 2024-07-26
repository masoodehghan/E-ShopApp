using ErrorOr;
using MediatR;
using ShopApp.Domain.OrderAggregate;

namespace ShopApp.Application.Orders.Commands;


public class OrderCommandHandler : IRequestHandler<OrderCommand, ErrorOr<Order>>
{
    public Task<ErrorOr<Order>> Handle(OrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

