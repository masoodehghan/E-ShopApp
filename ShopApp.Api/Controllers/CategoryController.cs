using System.Data;
using System.Security.Claims;
using Dapper;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Categories.Commands;
using ShopApp.Application.Categories.Queries;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Contracts.Categories;
using ShopApp.Contracts.Products;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.UserAggregate;

namespace ShopApp.Api.Controllers;


[Route("api/dashboard/category")]
public class CategoryController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    private readonly IDapperContext _dapperContext;

    public CategoryController(
        ISender mediatr,
        IMapper mapper,
        ICategoryRepository categoryRepository,
        IDapperContext dapperContext)
    {
        _mediatr = mediatr;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _dapperContext = dapperContext;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CategoryRequest request)
    {
        var command = _mapper.Map<CategoryCommand>((request, User));

        var result = await _mediatr.Send(command);

        return result.Match(
            category => Created("", _mapper.Map<CategoryResponse>(category)),
            error => Problem(error)
        );
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Get()
    {

        var categories = await _mediatr.Send(new CategoryListQuery());
        return Ok(categories);
    }

    [HttpPut]
    public async Task<IActionResult> Put(CategoryUpdateRequest request)
    {
        var query = _mapper.Map<CategoryUpdateQuery>((request, User));

        var result = await _mediatr.Send(query);

        return result.Match(
            category => Ok(_mapper.Map<CategoryResponse>(category)),
            errors => Problem(errors)
        );
    }

    

}
