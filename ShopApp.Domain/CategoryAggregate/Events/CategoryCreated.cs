using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.CategoryAggregate.Events;


public record CategoryCreated(Category Category) : IDomainEvent;
