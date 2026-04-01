using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Core.Application.Commands.DeliveryRiderCommands;

namespace MotoXShare.API.Controllers;

[Authorize(Roles = "Admin, DeliveryRider")]
[ApiController]
[Route("api/v1/[controller]")]
public class DeliveryRidersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreateDeliveryRiderCommand command)
    {
        var result = await mediator.Send(command);

        return Created($"{Request.Path}/{result.Data}", new { });
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCnhImage(int id, IFormFile cnhImage)
    {
        var result = await mediator.Send(new UpdateDeliveryRiderCommand(id, cnhImage));

        return result.IsSuccess ? NoContent() : NotFound();
    }
}