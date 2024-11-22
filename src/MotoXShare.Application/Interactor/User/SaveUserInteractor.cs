using MotoXShare.Application.Interactor.Interface.User;
using MotoXShare.Application.UseCase.User;
using MotoXShare.Domain.Dto.User;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.User;

public class SaveUserInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveUserUseCase saveUserUseCase
) : InteractorAsync<Guid, SaveUserRequestDto>(unitOfWork), ISaveUserInteractor
{
    protected override async Task<Guid> Action(SaveUserRequestDto param) =>
        await saveUserUseCase.Action(param);
}