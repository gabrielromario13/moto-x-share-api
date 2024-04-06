using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.User;
using MotoXShare.Domain.Dto.User;

namespace MotoXShare.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController(ISaveUserInteractor saveUserInteractor) : ControllerBase
{
    private readonly ISaveUserInteractor _saveUserInteractor = saveUserInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] SaveUserRequestDto param)
    {
        var result = await _saveUserInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", new { });
    }
}