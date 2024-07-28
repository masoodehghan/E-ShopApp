using System.Data;
using Dapper;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Application.Products.Commands;
using ShopApp.Application.Products.Queries;
using ShopApp.Contracts.Categories;
using ShopApp.Contracts.Products;
using ShopApp.Domain.Common.Errors;
using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Api.Controllers;


[Route("api/dashboard/product")]
public class ProductController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;
    private readonly IDapperContext _dapperContext;

    private readonly IProductRepository _productRepository;

    public ProductController(
        ISender mediatr,
        IMapper mapper,
        IProductRepository productRepository,
        IDapperContext dapperContext)
    {
        _mediatr = mediatr;
        _mapper = mapper;
        _productRepository = productRepository;
        _dapperContext = dapperContext;
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
        
        var products = await _mediatr.Send(new ProductListQuery());
        return Ok(products);
        
    }


    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
    {
        if(!Guid.TryParse(id, out Guid productId))  return NotFound();
        
        var product = await _productRepository.GetById(ProductId.Create(productId), cancellationToken);

        if(product is null)  return NotFound();

        return Ok(_mapper.Map<ProductResponse>(product));
    }

}
