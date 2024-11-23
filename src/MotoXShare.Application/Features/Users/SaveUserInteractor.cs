using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Users;

public class SaveUserInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveUserUseCase saveUserUseCase
) : InteractorAsync<Guid, SaveUserRequestDto>(unitOfWork), ISaveUserInteractor
{
    protected override async Task<Guid> Action(SaveUserRequestDto param) =>
        await saveUserUseCase.Action(param);
}