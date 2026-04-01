using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Core.Application.Models.ViewModels;

public record DeliveryRiderNotificationViewModel(
    int OrderId,
    IEnumerable<DeliveryRiderViewModel> DeliveryRiders)
{
    public static DeliveryRiderNotificationViewModel FromDomain(
        DeliveryRiderNotification param,
        IEnumerable<DeliveryRider> deliveryRiders) =>
            new(param.OrderId, deliveryRiders.Select(DeliveryRiderViewModel.FromDomain));
}