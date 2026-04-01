using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;
using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Application.Commands.DeliveryRiderNotificationCommands;

public class CreateDeliveryRiderNotificationCommandHandler(AppDbContext context)
    : IRequestHandler<CreateDeliveryRiderNotificationCommand, ResultViewModel>
{
    public virtual async Task<ResultViewModel> Handle(
        CreateDeliveryRiderNotificationCommand command,
        CancellationToken token)
    {
        var unavailableDeliveryRidersIds = (await context.Orders
            .AsNoTracking()
            .Where(o => o.Status == OrderStatus.Accepted).ToListAsync())
            .Select(o => o.DeliveryRiderId);

        var deliveryRidersIds = (await context.DeliveryRiders
            .AsNoTracking()
            .Include(d => d.Rental)
            .Where(d => d.Rental != null && !unavailableDeliveryRidersIds.Contains(d.Id)).ToListAsync())
            .Select(d => d.Id);

        if (!deliveryRidersIds.Any())
            return ResultViewModel.Error(string.Empty);

        var notification = command.ToEntity(deliveryRidersIds);

        context.DeliveryRiderNotifications.Add(notification);
        await context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}