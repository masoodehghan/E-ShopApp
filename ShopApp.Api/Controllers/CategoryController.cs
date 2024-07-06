using System.Security.Claims;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Categories.Commands;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Contracts.Categories;
using ShopApp.Domain.UserAggregate;

namespace ShopApp.Api.Controllers;


[Route("api/dashboard/category")]
public class CategoryController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ISender mediatr, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mediatr = mediatr;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
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
        var categories = await _categoryRepository.GetAll();
        return Ok(_mapper.Map<List<CategoryResponse>>(categories));
    }

    

}
