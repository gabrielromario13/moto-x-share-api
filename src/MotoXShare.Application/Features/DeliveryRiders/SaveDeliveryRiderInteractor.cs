using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.DeliveryRiders;

public class SaveDeliveryRiderInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveDeliveryRiderUseCase saveDeliveryRiderUseCase)
: InteractorAsync<Guid, SaveDeliveryRiderRequestDto>(unitOfWork), ISaveDeliveryRiderInteractor
{
    protected override async Task<Guid> Action(SaveDeliveryRiderRequestDto param) =>
        await saveDeliveryRiderUseCase.Action(param);
}