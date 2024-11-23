using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Enums;
using MotoXShare.Infraestructure.Data.Repository.Interface;
using MotoXShare.Infraestructure.UnitOfWork;
using System.Linq.Expressions;

namespace MotoXShare.Application.UseCase.Notification;

public class SaveNotificationUseCase(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    IOrderRepository orderRepository,
    IDeliveryRiderRepository deliveryRiderRepository,
    INotificationRepository repository
)
{
    public virtual async Task<bool> Action(Guid orderId)
    {
        var includeProperties = GetExpression();

        var unavailableDeliveryRidersIds = (await orderRepository
            .Get(o => o.Status == OrderStatus.Accepted))
            .Select(o => o.DeliveryRiderId);

        var deliveryRidersIds = (await deliveryRiderRepository
            .Get(d => d.Rental != null && !unavailableDeliveryRidersIds.Contains(d.Id), includeProperties))
            .Select(d => d.Id);

        if (!deliveryRidersIds.Any())
            return false;

        var notification = NotificationAdapter.ToDomain(orderId, deliveryRidersIds);

        await unitOfWork.BeginUnitAsync();

        await repository.Add(notification);

        await unitOfWork.CommitUnitAsync();

        return true;
    }

    private static List<Expression<Func<Domain.Model.DeliveryRider, object>>> GetExpression() =>
        [
            c => c.Rental
        ];
}