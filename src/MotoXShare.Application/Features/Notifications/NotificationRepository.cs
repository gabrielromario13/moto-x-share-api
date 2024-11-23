using Microsoft.EntityFrameworkCore;
using MotoXShare.Application.Data.Context;
using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Notifications;

public class NotificationRepository(ApplicationContext context)
    : RepositoryAsync<DeliveryRiderNotification>(context), INotificationRepository
{
    public async Task<bool> CheckIfDeliveryRiderWasNotified(Guid orderId, Guid deliveryRiderId) =>
        await DbSet.AsNoTracking().AnyAsync(n => n.OrderId == orderId && n.DeliveryRidersIds.Contains(deliveryRiderId));
}