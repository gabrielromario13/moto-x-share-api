using MotoXShare.Application.Features.Common;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Application.Features.Notifications;

public interface INotificationRepository : IRepositoryAsync<DeliveryRiderNotification>
{
    Task<bool> CheckIfDeliveryRiderWasNotified(Guid orderId, Guid deliveryRiderId);
}