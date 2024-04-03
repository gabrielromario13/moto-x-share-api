using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Order;
using MotoXShare.Infraestructure.Data.Repository.Interface;
using MotoXShare.Infraestructure.Messaging;

namespace MotoXShare.Application.UseCase.Order;

public class SaveOrderUseCase(
    IOrderRepository repository, 
    IMessageBusService messageBusService
)
{
    private readonly IOrderRepository _repository = repository;
    private readonly IMessageBusService _messageBusService = messageBusService;

    public virtual async Task<Guid> Action(SaveOrderRequestDto param)
    {
        var order = OrderAdapter.ToDomain(param);

        await _repository.Add(order);

        _messageBusService.Publish(order.Id);

        return order.Id;
    }
}