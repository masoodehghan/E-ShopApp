using ErrorOr;
using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.ProductAggregate.Events;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Application.Products.Events;

public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly ITagRepository _tagRepository;

    public ProductCreatedEventHandler(ICategoryRepository categoryRepository, ITagRepository tagRepository)
    {
        _categoryRepository = categoryRepository;
        _tagRepository = tagRepository;
    }

    public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
    {
        
        Category? category = await _categoryRepository
                            .GetById(notification.Prodcut.CategoryId, cancellationToken); 
        if (category is null)
        {
            CancellationTokenSource source = new();
            source.Cancel();
            await _categoryRepository.CancelOperation(source.Token);
            
        }
        else
        {
            category.AddProductId((ProductId)notification.Prodcut.Id);
        }

        foreach(var tagId in notification.Prodcut.TagIds)
        {
            var tag = await _tagRepository.GetById(tagId, cancellationToken);

            if(tag is null)
            {
                CancellationTokenSource source = new();
                source.Cancel();
                await _categoryRepository.CancelOperation(source.Token);
            }
            else
            {
                tag.AddProductId((ProductId)notification.Prodcut.Id);
            }

        }
    }   
}