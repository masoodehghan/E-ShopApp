using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Application.Products.Commands;


public class ProductCommandHandler : IRequestHandler<ProductCommand, ErrorOr<Product>>
{

    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductCommandHandler(
        IUserRepository userRepository,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }



    public async Task<ErrorOr<Product>> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByClaim(request.User, cancellationToken);
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }

        if(!Guid.TryParse(request.CategoryId, out Guid categoryIdGuid))
        {
            return Errors.Category.NotFound;
        }

        CategoryId categoryId = CategoryId.Create(categoryIdGuid);



        var product = Product.Create(
            request.Name,
            request.Price,
            request.Quantity,
            request.Description,
            categoryId);


        await _productRepository.Add(product, cancellationToken);

        return product;
    }
}

