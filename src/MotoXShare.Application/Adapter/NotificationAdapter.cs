using MotoXShare.Domain.Dto.Notification;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public class NotificationAdapter
{
    public static Notification ToDomain(Guid orderId, List<Guid> deliveryRidersIds) =>
        new()
        {
            OrderId = orderId,
            DeliveryRidersIds = deliveryRidersIds
        };

    public static GetNotificationResponseDto FromDomain(Notification param, IEnumerable<DeliveryRider> deliveryRiders) =>
        new()
        {
            OrderId = param.OrderId,
            DeliveryRiders = deliveryRiders.Select(d => DeliveryRiderAdapter.FromDomain(d))
        };
}