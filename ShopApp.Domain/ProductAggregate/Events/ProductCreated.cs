using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.ProductAggregate.Events;


public record ProductCreated(
    Product Prodcut
) : IDomainEvent;

