using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Adapter;
using MotoXShare.Application.Services;
using MotoXShare.Domain.Dto.User;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LoginController(
    IUserRepository userRepository,
    ITokenService tokenService
) : ControllerBase
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;

    [HttpPost]
    public async Task<IActionResult> Authenticate(AuthenticateUserDto param)
    {
        var user = await _userRepository.GetSingle(x => x.Username == param.Username && x.Password == x.Password);

        if (user is null)
            return NotFound();

        var token = _tokenService.GenerateToken(user);

        return Ok(UserAdapter.FromDomain(user, token));
    }
}