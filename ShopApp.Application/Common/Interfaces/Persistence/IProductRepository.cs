using ShopApp.Domain.ProductAggregate;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IProductRepository
{
    Task Add(Product product);
}

