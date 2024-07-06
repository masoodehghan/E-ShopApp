using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Products.Commands;
using ShopApp.Contracts.Products;

namespace ShopApp.Api.Controllers;


[Route("api/dashboard/product")]
public class ProductController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;

    public ProductController(ISender mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<IActionResult> Post(ProductCreateRequest request)
    {
        var command = _mapper.Map<ProductCommand>((request, User));

        var result = await _mediatr.Send(command);

        return result.Match(
            product => Created("", _mapper.Map<ProductResponse>(product)),
            errors => Problem(errors)
        );
    }

}
