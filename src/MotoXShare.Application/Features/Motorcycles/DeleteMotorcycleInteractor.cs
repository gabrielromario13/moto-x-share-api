using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Motorcycles;

public class DeleteMotorcycleInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    DeleteMotorcycleUseCase deleteMotorcycleUseCase
) : InteractorAsync<bool, Guid>(unitOfWork), IDeleteMotorcycleInteractor
{
    protected override async Task<bool> Action(Guid param) =>
        await deleteMotorcycleUseCase.Action(param);
}