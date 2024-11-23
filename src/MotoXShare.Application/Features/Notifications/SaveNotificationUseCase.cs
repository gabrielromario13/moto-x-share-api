using System.Linq.Expressions;
using MotoXShare.Application.Domain.Enums;
using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.DeliveryRiders;
using MotoXShare.Application.Features.Orders;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Notifications;

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

    private static List<Expression<Func<DeliveryRider, object>>> GetExpression() =>
        [
            c => c.Rental
        ];
}