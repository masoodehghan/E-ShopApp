using ErrorOr;
using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.ProductAggregate.ValueObjects;
using ShopApp.Domain.UserAggregate.Enums;

namespace ShopApp.Application.Products.Queries;


public class ProductDeleteQueryHandler : IRequestHandler<ProductDeleteQuery, ErrorOr<bool>>
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public ProductDeleteQueryHandler(IUserRepository userRepository, IProductRepository productRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<bool>> Handle(ProductDeleteQuery request, CancellationToken cancellationToken)
    { 
        var user = await _userRepository.GetUserByClaim(request.User);
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }

        if(!Guid.TryParse(request.Id, out Guid productId))
        {
            return Errors.Product.NotFound;
        }

        var product = await _productRepository.GetById(ProductId.Create(productId), cancellationToken);

        if(product is null)
        {
            return Errors.Product.NotFound;
        }

        await _productRepository.Delete(product);

        return true;

    }
}
