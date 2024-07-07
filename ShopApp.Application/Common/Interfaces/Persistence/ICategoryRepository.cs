using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.CategoryAggregate.ValueObjects;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface ICategoryRepository
{
    Task Add(Category category);
    
    Task<List<Category>> GetAll();

    Task<Category?> GetById(CategoryId id);
}
