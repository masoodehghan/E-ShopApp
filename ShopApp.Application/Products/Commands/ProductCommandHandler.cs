using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.CategoryAggregate;

namespace ShopApp.Application.Products.Commands;


public class ProductCommandHandler : IRequestHandler<ProductCommand, ErrorOr<Product>>
{
    private readonly UserManager<IdentityUser> _userManager;

    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductCommandHandler(
        UserManager<IdentityUser> userManager,
        IUserRepository userRepository,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }



    public async Task<ErrorOr<Product>> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        string userId = _userManager.GetUserId(request.User)!;
        var user = await _userRepository.GetUserById(Guid.Parse(userId));
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }

        if(!Guid.TryParse(request.CategoryId, out Guid categoryIdGuid))
        {
            return Errors.Category.NotFound;
        }

        CategoryId categoryId = CategoryId.Create(categoryIdGuid);


        if(await _categoryRepository.GetById(categoryId) is null)
        {
            return Errors.Category.NotFound;
        }

        var product = Product.Create(
            request.Name,
            request.Price,
            request.Quantity,
            request.Description,
            categoryId);

        await _productRepository.Add(product);

        return product;
    }
}

