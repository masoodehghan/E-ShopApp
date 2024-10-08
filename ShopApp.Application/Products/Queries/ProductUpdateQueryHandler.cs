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


    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductUpdateQueryHandler(
        IUserRepository userRepository,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }
    public async Task<ErrorOr<Product>> Handle(
        ProductUpdateQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByClaim(request.User, cancellationToken);
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }

        var product = await _productRepository.GetById(ProductId.Create(request.Id), cancellationToken);
        
        if(product is null)
        {
            return Errors.Product.NotFound;
        }

        product = Product.Update(
            product,
            request.Name,
            request.Price,
            (request.CategoryId is null) ? null : CategoryId.Create((Guid)request.CategoryId),
            request.Quantity,
            request.Description);

        await _productRepository.Update(product, cancellationToken);

        return product;
        
    }
}
