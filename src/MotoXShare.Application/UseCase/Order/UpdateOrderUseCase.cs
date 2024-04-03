using MotoXShare.Domain.Dto.Order;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Order;

public class UpdateOrderUseCase(IOrderRepository repository, INotificationRepository notificationRepository)
{
    private readonly INotificationRepository _notificationRepository = notificationRepository;
    private readonly IOrderRepository _repository = repository;

    public virtual async Task<bool> Action(UpdateOrderRequestDto param)
    {
        var order = await _repository.GetById(param.OrderId);

        if (order is null)
            return false;

        var notifiedDeliveryRider = await _notificationRepository
            .CheckIfDeliveryRiderWasNotified(param.OrderId, param.DeliveryRiderId);

        if (!notifiedDeliveryRider) //TODO: add notification
            return false;

        order.Update(param.DeliveryRiderId, order.Status);

        await _repository.Update(order);

        return true;
    }
}