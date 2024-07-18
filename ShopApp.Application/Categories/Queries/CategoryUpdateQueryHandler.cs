using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.CategoryAggregate.ValueObjects;

namespace ShopApp.Application.Categories.Queries;


public class CategoryUpdateQueryHandler : IRequestHandler<CategoryUpdateQuery, ErrorOr<Category>>
{

    private readonly ICategoryRepository _cateogryRepository;
    private readonly IUserRepository _userRepository;

    public CategoryUpdateQueryHandler(
        ICategoryRepository cateogryRepository,
        IUserRepository userRepository)
    {
        _cateogryRepository = cateogryRepository;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<Category>> Handle(
        CategoryUpdateQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByClaim(request.User);
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }

        bool isGuidCorrect = Guid.TryParse(request.CategoryId, out Guid res);
        if (isGuidCorrect == false)
        {
            return Errors.Category.NotFound;
        }

        var categoryToUpdate = 
                    await _cateogryRepository.GetById(CategoryId.Create(res));
        
        if (categoryToUpdate is null)
        {
            return Errors.Category.NotFound;
        }

        categoryToUpdate = Category.Update(categoryToUpdate, request.Name);
        await _cateogryRepository.Update(categoryToUpdate);
        return categoryToUpdate;

    }
}
