using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.UserAggregate.Events;


public record UserCreated(User User) : IDomainEvent;
