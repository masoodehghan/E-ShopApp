using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.CategoryAggregate.ValueObjects;

namespace ShopApp.Application.Products.Commands;


public class ProductCommandHandler : IRequestHandler<ProductCommand, ErrorOr<Product>>
{
    private readonly UserManager<IdentityUser> _userManager;

    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public ProductCommandHandler(UserManager<IdentityUser> userManager, IUserRepository userRepository, IProductRepository productRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }



    public async Task<ErrorOr<Product>> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        string userId = _userManager.GetUserId(request.User)!;
        var user = await _userRepository.GetUserById(Guid.Parse(userId));
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }

        var product = Product.Create(
            request.Name,
            request.Price,
            request.Quantity,
            request.Description,
            CategoryId.Create(request.CategoryId));

        await _productRepository.Add(product);

        return product;
    }
}

