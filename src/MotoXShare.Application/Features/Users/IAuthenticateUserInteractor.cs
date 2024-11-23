using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Users;

public interface IAuthenticateUserInteractor : IInteractorAsync<GetUserResponseDto, AuthenticateUserDto>
{
}