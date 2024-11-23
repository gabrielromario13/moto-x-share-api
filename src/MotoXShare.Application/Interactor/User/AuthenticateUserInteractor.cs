using MotoXShare.Application.Interactor.Interface.User;
using MotoXShare.Application.UseCase.User;
using MotoXShare.Domain.Dto.User;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.User;

public class AuthenticateUserInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    AuthenticateUserUseCase authenticateUserUseCase
) : InteractorAsync<GetUserResponseDto, AuthenticateUserDto>(unitOfWork), IAuthenticateUserInteractor
{
    protected override async Task<GetUserResponseDto> Action(AuthenticateUserDto param) =>
        await authenticateUserUseCase.Action(param);
}