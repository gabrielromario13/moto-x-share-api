using MotoXShare.Application.Features.DeliveryRiders;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Application.Features.Notifications;

public static class NotificationAdapter
{
    public static DeliveryRiderNotification ToDomain(Guid orderId, IEnumerable<Guid> deliveryRidersIds) =>
        new()
        {
            OrderId = orderId,
            DeliveryRidersIds = deliveryRidersIds.ToList()
        };

    public static GetNotificationResponseDto FromDomain(DeliveryRiderNotification param, IEnumerable<DeliveryRider> deliveryRiders) =>
        new()
        {
            OrderId = param.OrderId,
            DeliveryRiders = deliveryRiders.Select(DeliveryRiderAdapter.FromDomain)
        };
}