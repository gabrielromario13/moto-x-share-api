using MediatR;
using MotoXShare.Application.Messaging;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Commands.OrderCommands;

public class CreateOrderCommandHandler(
    AppDbContext context,
    IRabbitMqService messageBusService)
    : IRequestHandler<CreateOrderCommand, ResultViewModel<int>>
{
    public virtual async Task<ResultViewModel<int>> Handle(
        CreateOrderCommand request,
        CancellationToken token)
    {
        var order = request.ToEntity();

        await context.Orders.AddAsync(order);
        context.SaveChanges();

        messageBusService.Publish(order.Id);

        return ResultViewModel<int>.Success(order.Id);
    }
}