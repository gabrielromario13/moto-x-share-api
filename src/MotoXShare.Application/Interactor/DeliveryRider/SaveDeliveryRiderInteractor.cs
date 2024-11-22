using MotoXShare.Application.Interactor.Interface.DeliveryRider;
using MotoXShare.Application.UseCase.DeliveryRider;
using MotoXShare.Domain.Dto.DeliveryRider;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.DeliveryRider;

public class SaveDeliveryRiderInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveDeliveryRiderUseCase saveDeliveryRiderUseCase)
: InteractorAsync<Guid, SaveDeliveryRiderRequestDto>(unitOfWork), ISaveDeliveryRiderInteractor
{
    protected override async Task<Guid> Action(SaveDeliveryRiderRequestDto param) =>
        await saveDeliveryRiderUseCase.Action(param);
}