using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Application.Products.Commands;
using ShopApp.Application.Products.Queries;
using ShopApp.Contracts.Products;

namespace ShopApp.Api.Controllers;


[Route("api/dashboard/product")]
public class ProductController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;

    private readonly IProductRepository _productRepository;

    public ProductController(ISender mediatr, IMapper mapper, IProductRepository productRepository)
    {
        _mediatr = mediatr;
        _mapper = mapper;
        _productRepository = productRepository;
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

    [HttpPut]
    public async Task<IActionResult> Put(ProductUpdateRequest request)
    {
        var query = _mapper.Map<ProductUpdateQuery>((request, User));
        var result = await _mediatr.Send(query);

        return result.Match(
            product => Ok(_mapper.Map<ProductResponse>(product)),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(ProductDeleteRequest request)
    {
        var query = _mapper.Map<ProductDeleteQuery>((request, User));

        var result = await _mediatr.Send(query);

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Get()
    {
        var products = await _productRepository.GetAll();
        return Ok(_mapper.Map<List<ProductResponse>>(products));
    }

}
