using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Features.Orders;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController(
    ISaveOrderInteractor saveOrderInteractor,
    IUpdateOrderInteractor updateOrderInteractor
) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(SaveOrderRequestDto param)
    {
        var result = await saveOrderInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", new { });
    }

    [Authorize(Roles = "Admin, DeliveryRider")]
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [Required] Guid deliveryRiderId)
    {
        var result = await updateOrderInteractor.Execute(new(id, deliveryRiderId));

        return result ? NoContent() : NotFound();
    }
}