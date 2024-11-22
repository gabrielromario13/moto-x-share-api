using MotoXShare.Application.Interactor.Interface.Motorcycle;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Motorcycle;

public class SaveMotorcycleInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveMotorcycleUseCase saveMotorcycleUseCase
) : InteractorAsync<Guid, SaveMotorcycleRequestDto>(unitOfWork), ISaveMotorcycleInteractor
{
    protected override async Task<Guid> Action(SaveMotorcycleRequestDto param) =>
        await saveMotorcycleUseCase.Action(param);
}