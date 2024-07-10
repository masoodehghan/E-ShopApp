using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.ProductAggregate.Events;


public record ProductUpdated(Product Product) : IDomainEvent;

