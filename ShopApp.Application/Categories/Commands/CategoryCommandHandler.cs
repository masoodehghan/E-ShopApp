using ErrorOr;
using MediatR;
using ShopApp.Domain.CategoryAggregate;

namespace ShopApp.Application.Categories.Commands;


public class CategoryCommandHandler : IRequestHandler<CategoryCommand, ErrorOr<Category>>
{


    public async Task<ErrorOr<Category>> Handle(
        CategoryCommand request,
        CancellationToken cancellationToken)
    {

        
        Category cateogry = Category.Create(request.Name);

        return cateogry;

    }
}
