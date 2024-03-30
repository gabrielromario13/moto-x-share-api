using MotoXShare.Application.Interactor.Base;
using MotoXShare.Domain.Dto.DeliveryRider;

namespace MotoXShare.Application.Interactor.Interface.DeliveryRider;

public interface ISaveDeliveryRiderInteractor : IInteractorAsync<Guid, SaveDeliveryRiderRequestDto>
{
}