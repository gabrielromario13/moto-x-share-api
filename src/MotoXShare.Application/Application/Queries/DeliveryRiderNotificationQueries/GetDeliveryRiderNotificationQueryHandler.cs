using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Queries.DeliveryRiderNotificationQueries;

public class GetDeliveryRiderNotificationQueryHandler(AppDbContext context)
    : IRequestHandler<GetDeliveryRiderNotificationQuery, ResultViewModel<DeliveryRiderNotificationViewModel>>
{
    public virtual async Task<ResultViewModel<DeliveryRiderNotificationViewModel>> Handle(
        GetDeliveryRiderNotificationQuery query,
        CancellationToken token)
    {
        var notification = await context.DeliveryRiderNotifications
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.OrderId == query.OrderId);

        if (notification is null)
            return ResultViewModel<DeliveryRiderNotificationViewModel>
                .Error("Notificação não encontrada.");

        var deliveryRiders = await context.DeliveryRiders
            .AsNoTracking()
            .AsQueryable()
            .Where(d => notification.DeliveryRidersIds.Contains(d.Id))
            .ToListAsync();

        return ResultViewModel<DeliveryRiderNotificationViewModel>
            .Success(DeliveryRiderNotificationViewModel.FromDomain(notification, deliveryRiders));
    }
}