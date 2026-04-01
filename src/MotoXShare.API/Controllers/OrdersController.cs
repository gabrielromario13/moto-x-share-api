using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Core.Application.Commands.OrderCommands;
using System.ComponentModel.DataAnnotations;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreateOrderCommand command)
    {
        var result = await mediator.Send(command);

        return Created($"{Request.Path}/{result.Data}", new { });
    }

    [Authorize(Roles = "Admin, DeliveryRider")]
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [Required] int deliveryRiderId)
    {
        var result = await mediator.Send(new UpdateOrderCommand(id, deliveryRiderId));

        return result.IsSuccess ? NoContent() : NotFound();
    }
}