using Microsoft.EntityFrameworkCore;
using MotoXShare.Application.Features.Common;
using MotoXShare.Core.Data.Context;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Application.Features.Notifications;

public class NotificationRepository(AppDbContext context)
    : RepositoryAsync<DeliveryRiderNotification>(context), INotificationRepository
{
    public async Task<bool> CheckIfDeliveryRiderWasNotified(Guid orderId, Guid deliveryRiderId) =>
        await DbSet.AsNoTracking().AnyAsync(n => n.OrderId == orderId && n.DeliveryRidersIds.Contains(deliveryRiderId));
}