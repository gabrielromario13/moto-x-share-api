using MotoXShare.Domain.Dto.Notification;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public static class NotificationAdapter
{
    public static DeliveryRiderNotification ToDomain(Guid orderId, List<Guid> deliveryRidersIds) =>
        new()
        {
            OrderId = orderId,
            DeliveryRidersIds = deliveryRidersIds
        };

    public static GetNotificationResponseDto FromDomain(DeliveryRiderNotification param, IEnumerable<DeliveryRider> deliveryRiders) =>
        new()
        {
            OrderId = param.OrderId,
            DeliveryRiders = deliveryRiders.Select(DeliveryRiderAdapter.FromDomain)
        };
}