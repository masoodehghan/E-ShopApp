using ShopApp.Domain.CategoryAggregate;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface ICategoryRepository
{
    Task Add(Category category);
    
    Task<List<Category>> GetAll();
}
