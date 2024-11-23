using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Motorcycles;

public class SaveMotorcycleInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveMotorcycleUseCase saveMotorcycleUseCase
) : InteractorAsync<Guid, SaveMotorcycleRequestDto>(unitOfWork), ISaveMotorcycleInteractor
{
    protected override async Task<Guid> Action(SaveMotorcycleRequestDto param) =>
        await saveMotorcycleUseCase.Action(param);
}