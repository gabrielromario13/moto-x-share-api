using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Core.Application.Commands.DeliveryRiderNotificationCommands;

public record CreateDeliveryRiderNotificationCommand(int OrderId) : IRequest<ResultViewModel>
{
    public DeliveryRiderNotification ToEntity(IEnumerable<int> deliveryRidersIds) =>
        new(OrderId, deliveryRidersIds);
}