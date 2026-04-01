using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Core.Application.Commands.RentalCommands;

namespace MotoXShare.API.Controllers;

[Authorize(Roles = "Admin, DeliveryRider")]
[ApiController]
[Route("api/v1/[controller]")]
public class RentalsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreateRentalCommand command)
    {
        var result = await mediator.Send(command);

        return Created($"{Request.Path}/{result.Data}", string.Empty);
    }
}