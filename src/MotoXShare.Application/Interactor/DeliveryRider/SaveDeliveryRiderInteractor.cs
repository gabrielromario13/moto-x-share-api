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
    private readonly SaveDeliveryRiderUseCase _saveDeliveryRiderUseCase = saveDeliveryRiderUseCase;

    protected override async Task<Guid> Action(SaveDeliveryRiderRequestDto param) =>
        await _saveDeliveryRiderUseCase.Action(param);
}