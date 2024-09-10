using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Tags.Commands;
using ShopApp.Contracts.Tags;

namespace ShopApp.Api.Controllers;


[Route("api/dashboard/tag")]
public class TagController : ApiController
{

    private readonly IMapper _mapper;
    private readonly ISender _mediatr;

    public TagController(IMapper mapper, ISender mediatr)
    {
        _mapper = mapper;
        _mediatr = mediatr;
    }

    [HttpPost]
    public async Task<IActionResult> Post(TagCreateRequest request)
    {
        var command = _mapper.Map<TagCreateCommand>((request, User));

        var result = await _mediatr.Send(command);

        return result.Match(
            tag => Ok(_mapper.Map<TagResponse>(tag)),
            errors => Problem(errors)
        );
    }
}
