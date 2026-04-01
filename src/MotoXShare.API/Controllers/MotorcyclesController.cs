using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Core.Application.Commands.MotorcycleCommands;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Application.Queries.MotorcycleQueries;

namespace MotoXShare.API.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/v1/[controller]")]
public class MotorcyclesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreateMotorcycleCommand command)
    {
        var result = await mediator.Send(command);

        return Created($"{Request.Path}/{result.Data}", string.Empty);
    }

    [HttpGet]
    [ProducesResponseType(typeof(MotorcycleViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByPlate([FromQuery] GetMotorcycleByPlateQuery query)
    {
        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePlate(int id, [FromQuery] string plate)
    {
        var result = await mediator.Send(new UpdateMotorcycleCommand(id, plate));

        return result.IsSuccess ? NoContent() : NotFound();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(DeleteMotorcycleCommand command)
    {
        var result = await mediator.Send(command);

        return result.IsSuccess ? Ok() : NotFound();
    }
}