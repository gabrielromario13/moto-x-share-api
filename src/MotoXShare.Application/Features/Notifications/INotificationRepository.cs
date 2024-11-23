using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Notifications;

public interface INotificationRepository : IRepositoryAsync<DeliveryRiderNotification>
{
    Task<bool> CheckIfDeliveryRiderWasNotified(Guid orderId, Guid deliveryRiderId);
}