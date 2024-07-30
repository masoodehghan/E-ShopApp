using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.BuyerAggregate;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.UserAggregate.Events;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Application.Authentication.Events;


public class UserCreatedEventHandler : INotificationHandler<UserCreated>
{
    private readonly IBuyerRepository _buyerRepository;

    public UserCreatedEventHandler(IBuyerRepository buyerRepository)
    {
        _buyerRepository = buyerRepository;
    }

    public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        if (notification.User.Role == Roles.Buyer)
        {
            var buyer = Buyer.Create((UserId)notification.User.Id);
            await _buyerRepository.Add(buyer, cancellationToken);
        }
    }
}
