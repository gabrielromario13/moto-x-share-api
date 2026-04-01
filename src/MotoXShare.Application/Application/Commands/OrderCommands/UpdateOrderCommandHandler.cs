using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Commands.OrderCommands;

public class UpdateOrderCommandHandler(AppDbContext context)
    : IRequestHandler<UpdateOrderCommand, ResultViewModel>
{
    public virtual async Task<ResultViewModel> Handle(
        UpdateOrderCommand request,
        CancellationToken token)
    {
        var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == request.Id);

        if (order is null)
            return ResultViewModel.Error("Pedido não encontrado.");

        var notifiedDeliveryRider = await context.DeliveryRiderNotifications
            .AsNoTracking()
            .AnyAsync(n => n.OrderId == request.Id &&
                      n.DeliveryRidersIds.Contains(request.DeliveryRiderId));

        if (!notifiedDeliveryRider)
            return ResultViewModel.Error("Somente entregadores notificados podem aceitar pedidos.");

        order.Update(request.DeliveryRiderId, order.Status);

        context.Orders.Update(order);
        await context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}