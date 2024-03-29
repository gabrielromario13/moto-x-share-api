using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Motorcycle;

public class SaveMotorcycleInteractor : InteractorAsync<Guid, SaveMotorcycleRequestDto>, ISaveMotorcycleInteractor
{
    private readonly SaveMotorcycleUseCase _saveMotorcycleUseCase;

    public SaveMotorcycleInteractor(
        EntityFrameworkUnitOfWorkAsync unitOfWork,
        SaveMotorcycleUseCase saveMotorcycleUseCase
    ) : base(unitOfWork)
    {
        _saveMotorcycleUseCase = saveMotorcycleUseCase;
    }

    protected override async Task<Guid> Action(SaveMotorcycleRequestDto param) =>
        await _saveMotorcycleUseCase.Action(param);
}