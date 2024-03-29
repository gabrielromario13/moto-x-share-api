using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.Interactor.Motorcycle;
using MotoXShare.Domain.Dto.Motorcycle;
using System.Net;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MotorcyclesController(
    ISaveMotorcycleInteractor saveMotorcycleInteractor, 
    IGetMotorcyclesInteractor getMotorcyclesInteractor,
    IUpdateMotorcyclePlateInteractor updateMotorcyclePlateInteractor
) : ControllerBase
{
    private readonly ISaveMotorcycleInteractor _saveMotorcycleInteractor = saveMotorcycleInteractor;
    private readonly IGetMotorcyclesInteractor _getMotorcyclesInteractor = getMotorcyclesInteractor;
    private readonly IUpdateMotorcyclePlateInteractor _updateMotorcyclePlateInteractor = updateMotorcyclePlateInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] SaveMotorcycleRequestDto param)
    {
        var result = await _saveMotorcycleInteractor.Execute(param);

        if (result == Guid.Empty)
            return BadRequest();

        return Created($"{Request.Path}/{result}", new { });
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetMotorcycleResponseDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromQuery] GetMotorcycleRequestDto param)
    {
        var result = await _getMotorcyclesInteractor.Execute(param);

        return Ok(result);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(GetMotorcycleResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePlate(Guid id, [FromBody] string plate)
    {
        if (plate.IsNullOrEmpty())
            return BadRequest();

        var result = await _updateMotorcyclePlateInteractor.Execute(new() { Id = id, Plate = plate });

        return result is null
            ? NotFound()
            : Ok(result);
    }
}