using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IProductRepository
{
    Task Add(Product product, CancellationToken cancellationToken);

    Task<Product?> GetById(ProductId id, CancellationToken cancellationToken);
    Task CancelOperations(CancellationToken cancellationToken);

    Task<Product?> GetByIds(List<ProductId> productIds);

    Task Update(Product product);

    Task Delete(Product product);
    Task<List<Product>> GetAll();
}

