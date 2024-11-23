using MotoXShare.Application.Messaging;

namespace MotoXShare.Application.Features.Orders;

public class SaveOrderUseCase(
    IOrderRepository repository,
    IRabbitMqService messageBusService)
{
    public virtual async Task<Guid> Action(SaveOrderRequestDto param)
    {
        var order = OrderAdapter.ToDomain(param);

        await repository.Add(order);

        messageBusService.Publish(order.Id);

        return order.Id;
    }
}