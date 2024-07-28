using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Application.Orders.Commands;
using ShopApp.Contracts.Orders;

namespace ShopApp.Api.Controllers;


[Route("api/order")]
public class OrderControllers : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediatr;

    public OrderControllers(ISender mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> post(OrderCreateRequest request)
    {
        var command = _mapper.Map<OrderCommand>((request, User));

        try
        {
            var result = await _mediatr.Send(command);
            
            return result.Match(
            order => Ok(_mapper.Map<OrderResponse>(order)),
            errors => Problem(errors));
        }
        catch(OperationCanceledException e)
        {
            return Problem("error");
        }

        
    }
}
