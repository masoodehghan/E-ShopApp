using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.UserAggregate;
using ShopApp.Domain.UserAggregate.Enums;

namespace ShopApp.Application.Categories.Commands;


public class CategoryCommandHandler : IRequestHandler<CategoryCommand, ErrorOr<Category>>
{

    private readonly ICategoryRepository _cateogryRepository;
    private readonly IUserRepository _userRepository;

    public CategoryCommandHandler(
        ICategoryRepository cateogryRepository,
        IUserRepository userRepository)
    {
        _cateogryRepository = cateogryRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Category>> Handle(
        CategoryCommand request,
        CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetUserByClaim(request.User);
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }

        var category = Category.Create(request.Name);
        await _cateogryRepository.Add(category, cancellationToken);

        return category;

    }
}
