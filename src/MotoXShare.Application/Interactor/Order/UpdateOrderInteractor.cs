using MotoXShare.Application.Interactor.Interface.Order;
using MotoXShare.Application.UseCase.Order;
using MotoXShare.Domain.Dto.Order;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Order;

public class UpdateOrderInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    UpdateOrderUseCase updateOrderUseCase
) : InteractorAsync<bool, UpdateOrderRequestDto>(unitOfWork), IUpdateOrderInteractor
{
    protected override async Task<bool> Action(UpdateOrderRequestDto param) =>
        await updateOrderUseCase.Action(param);
}