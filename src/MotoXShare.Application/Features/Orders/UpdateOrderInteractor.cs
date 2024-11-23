using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Orders;

public class UpdateOrderInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    UpdateOrderUseCase updateOrderUseCase
) : InteractorAsync<bool, UpdateOrderRequestDto>(unitOfWork), IUpdateOrderInteractor
{
    protected override async Task<bool> Action(UpdateOrderRequestDto param) =>
        await updateOrderUseCase.Action(param);
}