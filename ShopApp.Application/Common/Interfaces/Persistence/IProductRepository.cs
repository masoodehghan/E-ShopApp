using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IProductRepository
{
    Task Add(Product product, CancellationToken cancellationToken);

    Task<Product?> GetById(ProductId id, CancellationToken cancellationToken);
    Task CancelOperations(CancellationToken cancellationToken);

    Task<Product?> GetByIds(List<ProductId> productIds, CancellationToken cancellationToken);

    Task Update(Product product, CancellationToken cancellationToken);

    Task Delete(Product product, CancellationToken cancellationToken);

    Task<List<Product>> GetAll(CancellationToken cancellationToken);
}

