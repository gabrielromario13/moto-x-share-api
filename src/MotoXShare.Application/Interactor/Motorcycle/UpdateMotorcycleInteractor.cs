using MotoXShare.Application.Interactor.Interface.Motorcycle;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Motorcycle;

public class UpdateMotorcycleInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    UpdateMotorcycleUseCase updateMotorcycleUseCase
) : InteractorAsync<bool, UpdateMotorcycleRequestDto>(unitOfWork), IUpdateMotorcycleInteractor
{
    protected override async Task<bool> Action(UpdateMotorcycleRequestDto param) =>
        await updateMotorcycleUseCase.Action(param);
}