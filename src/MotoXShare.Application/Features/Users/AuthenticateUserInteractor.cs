using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Users;

public class AuthenticateUserInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    AuthenticateUserUseCase authenticateUserUseCase
) : InteractorAsync<GetUserResponseDto, AuthenticateUserDto>(unitOfWork), IAuthenticateUserInteractor
{
    protected override async Task<GetUserResponseDto> Action(AuthenticateUserDto param) =>
        await authenticateUserUseCase.Action(param);
}