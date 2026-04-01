using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Core.Application.Commands.AuthenticateUserCommands;
using MotoXShare.Core.Application.Models.ViewModels;

namespace MotoXShare.API.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class LoginController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(AuthenticateUserViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Authenticate(AuthenticateUserCommand command)
    {
        var result = await mediator.Send(command);

        return result.IsSuccess ? NotFound() : Ok(result);
    }
}