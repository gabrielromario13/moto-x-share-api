using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Orders;

public class SaveOrderInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveOrderUseCase saveOrderUseCase
) : InteractorAsync<Guid, SaveOrderRequestDto>(unitOfWork), ISaveOrderInteractor
{
    protected override async Task<Guid> Action(SaveOrderRequestDto param) =>
        await saveOrderUseCase.Action(param);
}