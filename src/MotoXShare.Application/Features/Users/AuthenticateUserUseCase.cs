using MotoXShare.Application.Hash;
using MotoXShare.Application.Services;

namespace MotoXShare.Application.Features.Users;

public class AuthenticateUserUseCase(
    IUserRepository repository, ITokenService tokenService)
{
    public virtual async Task<GetUserResponseDto> Action(AuthenticateUserDto param)
    {
        var password = HashUtils.HashPassword(param.Password);
        var user = await repository.GetSingle(x => x.Username == param.Username && x.Password == password);

        if (user is null)
            return default;

        var token = tokenService.GenerateToken(user);

        return UserAdapter.FromDomain(user, token);
    }
}