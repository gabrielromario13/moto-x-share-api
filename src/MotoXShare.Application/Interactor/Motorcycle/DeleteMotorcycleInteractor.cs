using MotoXShare.Application.Interactor.Interface.Motorcycle;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Motorcycle;

public class DeleteMotorcycleInteractor : InteractorAsync<bool, Guid>, IDeleteMotorcycleInteractor
{
    private readonly DeleteMotorcycleUseCase _deleteMotorcycleUseCase;

    public DeleteMotorcycleInteractor(
        EntityFrameworkUnitOfWorkAsync unitOfWork,
        DeleteMotorcycleUseCase deleteMotorcycleUseCase
    ) : base(unitOfWork)
    {
        _deleteMotorcycleUseCase = deleteMotorcycleUseCase;
    }

    protected override async Task<bool> Action(Guid param) =>
        await _deleteMotorcycleUseCase.Action(param);
}