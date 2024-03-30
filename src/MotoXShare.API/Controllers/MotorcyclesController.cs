using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MotoXShare.Application.Adapter;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.Interactor.Interface.Motorcycle;
using MotoXShare.Domain.Dto.Motorcycle;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MotorcyclesController(
    ISaveMotorcycleInteractor saveMotorcycleInteractor,
    IGetMotorcyclesInteractor getMotorcyclesInteractor,
    IUpdateMotorcyclePlateInteractor updateMotorcyclePlateInteractor,
    IDeleteMotorcycleInteractor deleteMotorcycleInteractor
) : ControllerBase
{
    private readonly ISaveMotorcycleInteractor _saveMotorcycleInteractor = saveMotorcycleInteractor;
    private readonly IGetMotorcyclesInteractor _getMotorcyclesInteractor = getMotorcyclesInteractor;
    private readonly IUpdateMotorcyclePlateInteractor _updateMotorcyclePlateInteractor = updateMotorcyclePlateInteractor;
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
    [ProducesResponseType(typeof(GetMotorcycleResponseDto), StatusCodes.Status200OK)] //TODO: This is right or should I use NoContent instead?
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePlate(Guid id, [FromBody] string plate)
    {
        if (plate.IsNullOrEmpty()) //TODO: Use FluentValidation instead of this!
            return BadRequest();

        var result = await _updateMotorcyclePlateInteractor.Execute(
            MotorcycleAdapter.ToUpdateMotorcyclePlateRequestDto(id, plate)
        );

        return result is null
            ? NotFound()
            : Ok(result);
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