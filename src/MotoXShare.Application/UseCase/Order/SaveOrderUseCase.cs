using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Order;
using MotoXShare.Infraestructure.Data.Repository.Interface;
using MotoXShare.Infraestructure.Messaging;

namespace MotoXShare.Application.UseCase.Order;

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