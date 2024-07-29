using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.ProductAggregate.Events;


public record ProductDeleted(
    Product Product
) : IDomainEvent;
