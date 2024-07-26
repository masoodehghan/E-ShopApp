using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IProductRepository
{
    Task Add(Product product);

    Task<Product?> GetById(ProductId id);

    Task<Product?> GetByIds(List<ProductId> productIds);

    Task Update(Product product);

    Task Delete(Product product);
    Task<List<Product>> GetAll();
}

