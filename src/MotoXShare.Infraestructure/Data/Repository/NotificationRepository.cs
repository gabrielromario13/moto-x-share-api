using Microsoft.EntityFrameworkCore;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Infraestructure.Data.Repository;

public class NotificationRepository(ApplicationContext context)
    : RepositoryAsync<DeliveryRiderNotification>(context), INotificationRepository
{
    public async Task<bool> CheckIfDeliveryRiderWasNotified(Guid orderId, Guid deliveryRiderId) =>
        await _dbSet.AsNoTracking().AnyAsync(n => n.OrderId == orderId && n.DeliveryRidersIds.Contains(deliveryRiderId));
}