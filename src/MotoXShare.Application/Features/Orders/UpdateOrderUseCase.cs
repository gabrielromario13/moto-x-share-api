using MotoXShare.Application.Features.Notifications;

namespace MotoXShare.Application.Features.Orders;

public class UpdateOrderUseCase(
    IOrderRepository repository,
    INotificationRepository notificationRepository,
    NotificationHandler notificationHandler)
{
    public virtual async Task<bool> Action(UpdateOrderRequestDto param)
    {
        var order = await repository.GetById(param.Id);

        if (order is null)
            return false;

        var notifiedDeliveryRider = await notificationRepository
            .CheckIfDeliveryRiderWasNotified(param.Id, param.DeliveryRiderId);

        if (!notifiedDeliveryRider)
        {
            notificationHandler.Add(new("Somente entregadores notificados podem aceitar pedidos.", "UnnotifiedDeliveryRider"));
            return false;
        }

        order.Update(param.DeliveryRiderId, order.Status);

        await repository.Update(order);

        return true;
    }
}