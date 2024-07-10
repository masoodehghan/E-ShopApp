using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.ProductAggregate.ValueObjects;
using ShopApp.Domain.CategoryAggregate.ValueObjects;

namespace ShopApp.Application.Products.Queries;


public class ProductUpdateQueryHandler : IRequestHandler<ProductUpdateQuery, ErrorOr<Product>>
{

    private readonly UserManager<IdentityUser> _userManager;

    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductUpdateQueryHandler(
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
    public async Task<ErrorOr<Product>> Handle(
        ProductUpdateQuery request,
        CancellationToken cancellationToken)
    {
        string userId = _userManager.GetUserId(request.User)!;
        var user = await _userRepository.GetUserById(Guid.Parse(userId));
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }

        if(!Guid.TryParse(request.Id, out Guid productId))
        {
            return Errors.Product.NotFound;
        }

        if(!Guid.TryParse(request.CategoryId, out Guid categoryId))
        {
            return Errors.Category.NotFound;
        }

        var product = await _productRepository.GetById(ProductId.Create(productId));
        
        if(product is null)
        {
            return Errors.Product.NotFound;
        }

        product = Product.Update(
            product,
            request.Name,
            request.Price,
            CategoryId.Create(categoryId),
            request.Quantity,
            request.Description);

        await _productRepository.Update(product);

        return product;
        
    }
}
