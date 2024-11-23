using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Features.Motorcycles;

namespace MotoXShare.API.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/v1/[controller]")]
public class MotorcyclesController(
    ISaveMotorcycleInteractor saveMotorcycleInteractor,
    IGetMotorcyclesInteractor getMotorcyclesInteractor,
    IUpdateMotorcycleInteractor updateMotorcycleInteractor,
    IDeleteMotorcycleInteractor deleteMotorcycleInteractor
) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(SaveMotorcycleRequestDto param)
    {
        var result = await saveMotorcycleInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", string.Empty);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetMotorcycleResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] GetMotorcycleRequestDto param)
    {
        var result = await getMotorcyclesInteractor.Execute(param);

        return Ok(result);
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePlate(Guid id, [FromQuery] string plate)
    {
        var result = await updateMotorcycleInteractor.Execute(new(id, plate));

        return result ? NoContent() : NotFound();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await deleteMotorcycleInteractor.Execute(id);

        return result ? Ok() : NotFound();
    }
}