using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Notification;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Notification;

public class GetNotificationUseCase(INotificationRepository repository, IDeliveryRiderRepository deliveryRiderRepository)
{
    private readonly INotificationRepository _repository = repository;
    private readonly IDeliveryRiderRepository _deliveryRiderRepository = deliveryRiderRepository;

    public virtual async Task<GetNotificationResponseDto> Action(Guid orderId)
    {
        var notification = await _repository.GetSingle(r => r.OrderId == orderId);

        if (notification is null) 
            return default;

        var deliveryRiders = await _deliveryRiderRepository.Get(d => notification.DeliveryRidersIds.Contains(d.Id));

        return NotificationAdapter.FromDomain(notification, deliveryRiders);
    }
}