using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.CategoryAggregate.ValueObjects;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface ICategoryRepository
{
    Task Add(Category category, CancellationToken cancellationToken);
    
    Task<List<Category>> GetAll(CancellationToken cancellationToken);

    Task<Category?> GetById(CategoryId id, CancellationToken cancellationToken);

    Task Update(Category category, CancellationToken cancellationToken);

    Task Delete(Category category, CancellationToken cancellationToken);


    Task CancelOperation(CancellationToken cancellationToken);

}
