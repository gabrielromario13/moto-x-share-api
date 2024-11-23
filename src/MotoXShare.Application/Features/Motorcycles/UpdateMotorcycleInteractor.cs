using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Motorcycles;

public class UpdateMotorcycleInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    UpdateMotorcycleUseCase updateMotorcycleUseCase
) : InteractorAsync<bool, UpdateMotorcycleRequestDto>(unitOfWork), IUpdateMotorcycleInteractor
{
    protected override async Task<bool> Action(UpdateMotorcycleRequestDto param) =>
        await updateMotorcycleUseCase.Action(param);
}