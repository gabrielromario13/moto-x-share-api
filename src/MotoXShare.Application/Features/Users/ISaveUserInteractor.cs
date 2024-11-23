using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Users;

public interface ISaveUserInteractor : IInteractorAsync<Guid, SaveUserRequestDto>
{
}