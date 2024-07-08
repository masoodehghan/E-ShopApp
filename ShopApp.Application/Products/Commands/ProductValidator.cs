using FluentValidation;
using ShopApp.Domain.ProductAggregate;

namespace ShopApp.Application.Products.Commands;


public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}
