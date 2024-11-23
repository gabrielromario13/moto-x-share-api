using MotoXShare.Application.Interactor.Interface.DeliveryRider;
using MotoXShare.Application.UseCase.DeliveryRider;
using MotoXShare.Domain.Dto.DeliveryRider;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.DeliveryRider;

public class UpdateDeliveryRiderInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    UpdateDeliveryRiderUseCase updateDeliveryRiderUseCase
) : InteractorAsync<bool, UpdateDeliveryRiderRequestDto>(unitOfWork), IUpdateDeliveryRiderInteractor
{
    protected override async Task<bool> Action(UpdateDeliveryRiderRequestDto param) =>
        await updateDeliveryRiderUseCase.Action(param);
}