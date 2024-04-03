using Microsoft.EntityFrameworkCore;
using MotoXShare.Domain.Model;

namespace MotoXShare.Infraestructure.Data.Repository.Interface;

public interface INotificationRepository : IRepositoryAsync<DeliveryRiderNotification>
{
    Task<bool> CheckIfDeliveryRiderWasNotified(Guid orderId, Guid deliveryRiderId);
}