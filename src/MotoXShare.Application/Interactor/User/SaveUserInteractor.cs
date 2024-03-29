using MotoXShare.Application.Interactor.Base;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.UseCase.User;
using MotoXShare.Domain.Dto.User;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.User;

public class SaveUserInteractor : InteractorAsync<Guid, SaveUserRequestDto>, ISaveUserInteractor
{
    private readonly SaveUserUseCase _saveUserUseCase;

    public SaveUserInteractor(EntityFrameworkUnitOfWorkAsync unitOfWork,
                              SaveUserUseCase saveUserUseCase) : base(unitOfWork)
    {
        _saveUserUseCase = saveUserUseCase;
    }

    protected override async Task<Guid> Action(SaveUserRequestDto param) =>
        await _saveUserUseCase.Action(param);
}