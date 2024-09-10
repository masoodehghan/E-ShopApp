using ErrorOr;
using MediatR;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.TagAggregate;
using ShopApp.Domain.UserAggregate.Enums;

namespace ShopApp.Application.Tags.Commands;


public class TagCreateCommandHandler : IRequestHandler<TagCreateCommand, ErrorOr<Tag>>
{

    private readonly IUserRepository _userRepository;
    private readonly ITagRepository _tagRepository;

    public TagCreateCommandHandler(
        IUserRepository userRepository,
        ITagRepository tagRepository)
    {
        _userRepository = userRepository;
        _tagRepository = tagRepository;
    }

    public async Task<ErrorOr<Tag>> Handle(
        TagCreateCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByClaim(request.User, cancellationToken);
        if(user is null || user.Role == Roles.Buyer)
        {
            return Errors.Authentication.Forbidden;
        }        

        var tag = Tag.Create(request.Name);
        await _tagRepository.Add(tag, cancellationToken);

        return tag;
    }
}
