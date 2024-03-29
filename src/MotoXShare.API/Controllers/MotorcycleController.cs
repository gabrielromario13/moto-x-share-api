using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Domain.Dto.Motorcycle;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MotorcyclesController : ControllerBase
{
    private readonly ISaveMotorcycleInteractor _saveMotorcycleInteractor;

    public MotorcyclesController(ISaveMotorcycleInteractor saveMotorcycleInteractor)
    {
        _saveMotorcycleInteractor = saveMotorcycleInteractor;
    }

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
}