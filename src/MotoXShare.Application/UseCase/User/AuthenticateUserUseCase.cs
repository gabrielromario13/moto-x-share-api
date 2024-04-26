using MotoXShare.Application.Adapter;
using MotoXShare.Application.Hash;
using MotoXShare.Application.Services;
using MotoXShare.Domain.Dto.User;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.User;

public class AuthenticateUserUseCase(
    IUserRepository repository, ITokenService tokenService)
{
    private readonly IUserRepository _repository = repository;
    private readonly ITokenService _tokenService = tokenService;

    public virtual async Task<GetUserResponseDto> Action(AuthenticateUserDto param)
    {
        var password = HashUtils.HashPassword(param.Password);
        var user = await _repository.GetSingle(x => x.Username == param.Username && x.Password == password);

        if (user is null)
            return default;

        var token = _tokenService.GenerateToken(user);

        return UserAdapter.FromDomain(user, token);
    }
}