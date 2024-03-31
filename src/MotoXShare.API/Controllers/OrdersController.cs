using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.Order;
using MotoXShare.Domain.Dto.Order;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(ISaveOrderInteractor saveOrderInteractor) : ControllerBase
{
    private readonly ISaveOrderInteractor _saveOrderInteractor = saveOrderInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] SaveOrderRequestDto param)
    {
        var result = await _saveOrderInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", new { });
    }
}