using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.User;
using MotoXShare.Domain.Dto.User;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ISaveUserInteractor _saveUserInteractor;

    public UsersController(ISaveUserInteractor saveUserInteractor)
    {
        _saveUserInteractor = saveUserInteractor;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] SaveUserRequestDto param)
    {
        var result = await _saveUserInteractor.Execute(param);

        if (result == Guid.Empty)
            return BadRequest();

        return Created($"{Request.Path}/{result}", new { });
    }
}