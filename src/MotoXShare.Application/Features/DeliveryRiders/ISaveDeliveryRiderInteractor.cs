using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.DeliveryRiders;

public interface ISaveDeliveryRiderInteractor : IInteractorAsync<Guid, SaveDeliveryRiderRequestDto>
{
}