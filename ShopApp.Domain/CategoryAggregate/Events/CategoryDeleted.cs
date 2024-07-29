using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.CategoryAggregate.Events;


public record CategoryDeleted(
    Category Category
) : IDomainEvent;
