using MotoXShare.Application.Interactor.Base;
using MotoXShare.Domain.Dto.User;

namespace MotoXShare.Application.Interactor.Interface.User;

public interface IAuthenticateUserInteractor : IInteractorAsync<GetUserResponseDto, AuthenticateUserDto>
{
}