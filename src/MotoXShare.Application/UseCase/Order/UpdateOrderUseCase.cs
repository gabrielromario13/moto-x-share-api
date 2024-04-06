using MotoXShare.Domain.Dto.Order;
using MotoXShare.Domain.Notification;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Order;

public class UpdateOrderUseCase(
    IOrderRepository repository,
    INotificationRepository notificationRepository,
    NotificationHandler notificationHandler)
{
    private readonly IOrderRepository _repository = repository;
    private readonly INotificationRepository _notificationRepository = notificationRepository;
    private readonly NotificationHandler _notificationHandler = notificationHandler;

    public virtual async Task<bool> Action(UpdateOrderRequestDto param)
    {
        var order = await _repository.GetById(param.Id);

        if (order is null)
            return false;

        var notifiedDeliveryRider = await _notificationRepository
            .CheckIfDeliveryRiderWasNotified(param.Id, param.DeliveryRiderId);

        if (!notifiedDeliveryRider)
        {
            _notificationHandler.Add(new("Entregador não foi notificado.", "UnnotifiedDeliveryRider"));
            return false;
        }

        order.Update(param.DeliveryRiderId, order.Status);

        await _repository.Update(order);

        return true;
    }
}