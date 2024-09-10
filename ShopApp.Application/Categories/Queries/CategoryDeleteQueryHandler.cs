using ErrorOr;
using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.CategoryAggregate.Events;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.Common.Errors;

namespace ShopApp.Application.Categories.Queries;


public class CategoryDeleteQueryHandler : IRequestHandler<CategoryDeleteQuery, ErrorOr<bool>>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryDeleteQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<ErrorOr<bool>> Handle(CategoryDeleteQuery request, CancellationToken cancellationToken)
    {
      
        var category = await _categoryRepository.
                            GetById(CategoryId.Create(request.CategoryId), cancellationToken);

        if(category is null)
        {
            return Errors.Category.NotFound;
        }
        await _categoryRepository.Delete(category, cancellationToken);
        category.AddDomainEvents(new CategoryDeleted(category));

        return true;
    }
}
