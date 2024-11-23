using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Features.Users;

namespace MotoXShare.API.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class LoginController(IAuthenticateUserInteractor authenticateUserInteractor) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetUserResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Authenticate(AuthenticateUserDto param)
    {
        var result = await authenticateUserInteractor.Execute(param);

        return result == default ? NotFound() : Ok(result);
    }
}