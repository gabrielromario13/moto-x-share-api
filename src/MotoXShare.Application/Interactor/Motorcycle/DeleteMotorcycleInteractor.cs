using MotoXShare.Application.Interactor.Interface.Motorcycle;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Motorcycle;

public class DeleteMotorcycleInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    DeleteMotorcycleUseCase deleteMotorcycleUseCase
) : InteractorAsync<bool, Guid>(unitOfWork), IDeleteMotorcycleInteractor
{
    protected override async Task<bool> Action(Guid param) =>
        await deleteMotorcycleUseCase.Action(param);
}