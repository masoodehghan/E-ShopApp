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
    private readonly UserManager<IdentityUser> _userManager;

    private readonly ICategoryRepository _cateogryRepository;
    private readonly IUserRepository _userRepository;

    public CategoryCommandHandler(
        ICategoryRepository cateogryRepository,
        UserManager<IdentityUser> userManager,
        IUserRepository userRepository)
    {
        _cateogryRepository = cateogryRepository;
        _userManager = userManager;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Category>> Handle(
        CategoryCommand request,
        CancellationToken cancellationToken)
    {

        string userId = _userManager.GetUserId(request.User)!;
        var user = await _userRepository.GetUserById(Guid.Parse(userId));
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }

        var category = Category.Create(request.Name);
        await _cateogryRepository.Add(category);

        return category;

    }
}
