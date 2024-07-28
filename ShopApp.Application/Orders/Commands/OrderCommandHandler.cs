using ErrorOr;
using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.BuyerAggregate.ValueObjects;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.OrderAggregate;
using ShopApp.Domain.OrderAggregate.Entities;
using ShopApp.Domain.OrderAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate.ValueObjects;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Application.Orders.Commands;


public class OrderCommandHandler : IRequestHandler<OrderCommand, ErrorOr<Order>>
{
    private readonly IBuyerRepository _buyerRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public OrderCommandHandler(
        IBuyerRepository buyerRepository,
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IUserRepository userRepository)
    {
        _buyerRepository = buyerRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Order>> Handle(OrderCommand request, CancellationToken cancellationToken)
    {
        var random = new Random();
        
        foreach(var d in request.OrderItems)
        {
            if(!Guid.TryParse(d.ProductId, out Guid productId))
            {
                return Errors.Product.NotFound;
            } 
        }


        var user = await _userRepository.GetUserByClaim(request.User);
        if(user is null) return Errors.Authentication.Forbidden;

        var buyer = await _buyerRepository.GetByUserId((UserId)user.Id);

        var order = Order.Create(
                random.Next(10000,  9999999),
                Address.Create(
                    request.Address.City,
                    request.Address.Street,
                    request.Address.Code),
                (BuyerId)buyer.Id,
                
                request.OrderItems.ConvertAll(orderItem => 
                        OrderItem.Create(
                            orderItem.Quantity,
                            ProductId.Create(Guid.Parse(orderItem.ProductId))))
                );
        await _orderRepository.Add(order, cancellationToken);
        
        return order;
    }
}

