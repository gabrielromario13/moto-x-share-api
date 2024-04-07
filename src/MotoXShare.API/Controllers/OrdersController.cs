using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.Order;
using MotoXShare.Domain.Dto.Order;

namespace MotoXShare.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OrdersController(
    ISaveOrderInteractor saveOrderInteractor,
    IUpdateOrderInteractor updateOrderInteractor
) : ControllerBase
{
    private readonly ISaveOrderInteractor _saveOrderInteractor = saveOrderInteractor;
    private readonly IUpdateOrderInteractor _updateOrderInteractor = updateOrderInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] SaveOrderRequestDto param)
    {
        var result = await _saveOrderInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", new { });
    }

    [AllowAnonymous]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] Guid deliveryRiderId)
    {
        var result = await _updateOrderInteractor.Execute(new(id, deliveryRiderId));

        return result ? NoContent() : NotFound();
    }
}