using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.Interactor.Interface.Motorcycle;
using MotoXShare.Domain.Dto.Motorcycle;

namespace MotoXShare.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MotorcyclesController(
    ISaveMotorcycleInteractor saveMotorcycleInteractor,
    IGetMotorcyclesInteractor getMotorcyclesInteractor,
    IUpdateMotorcycleInteractor updateMotorcycleInteractor,
    IDeleteMotorcycleInteractor deleteMotorcycleInteractor
) : ControllerBase
{
    private readonly ISaveMotorcycleInteractor _saveMotorcycleInteractor = saveMotorcycleInteractor;
    private readonly IGetMotorcyclesInteractor _getMotorcyclesInteractor = getMotorcyclesInteractor;
    private readonly IUpdateMotorcycleInteractor _updateMotorcycleInteractor = updateMotorcycleInteractor;
    private readonly IDeleteMotorcycleInteractor _deleteMotorcycleInteractor = deleteMotorcycleInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(SaveMotorcycleRequestDto param)
    {
        var result = await _saveMotorcycleInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", string.Empty);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetMotorcycleResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] GetMotorcycleRequestDto param)
    {
        var result = await _getMotorcyclesInteractor.Execute(param);

        return Ok(result);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePlate(Guid id, [FromQuery] string plate)
    {
        var result = await _updateMotorcycleInteractor.Execute(new(id, plate));

        return result ? NoContent() : NotFound();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _deleteMotorcycleInteractor.Execute(id);

        return result ? Ok() : NotFound();
    }
}