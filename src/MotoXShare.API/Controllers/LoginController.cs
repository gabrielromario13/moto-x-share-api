using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.User;
using MotoXShare.Domain.Dto.User;

namespace MotoXShare.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IAuthenticateUserInteractor authenticateUserInteractor) : ControllerBase
    {
        private readonly IAuthenticateUserInteractor _authenticateUserInteractor = authenticateUserInteractor;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetUserResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Authenticate(AuthenticateUserDto param)
        {
            var result = await _authenticateUserInteractor.Execute(param);

            return result == default ? NotFound() : Ok(result);
        }
    }
}