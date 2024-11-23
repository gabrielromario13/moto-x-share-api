using MotoXShare.Application.Interactor.Interface.Order;
using MotoXShare.Application.UseCase.Order;
using MotoXShare.Domain.Dto.Order;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Order;

public class SaveOrderInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveOrderUseCase saveOrderUseCase
) : InteractorAsync<Guid, SaveOrderRequestDto>(unitOfWork), ISaveOrderInteractor
{
    protected override async Task<Guid> Action(SaveOrderRequestDto param) =>
        await saveOrderUseCase.Action(param);
}