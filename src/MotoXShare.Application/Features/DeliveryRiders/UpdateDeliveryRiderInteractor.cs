using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.DeliveryRiders;

public class UpdateDeliveryRiderInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    UpdateDeliveryRiderUseCase updateDeliveryRiderUseCase
) : InteractorAsync<bool, UpdateDeliveryRiderRequestDto>(unitOfWork), IUpdateDeliveryRiderInteractor
{
    protected override async Task<bool> Action(UpdateDeliveryRiderRequestDto param) =>
        await updateDeliveryRiderUseCase.Action(param);
}