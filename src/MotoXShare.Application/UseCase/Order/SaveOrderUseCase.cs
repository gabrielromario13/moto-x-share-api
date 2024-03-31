using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Order;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Order;

public class SaveOrderUseCase(IOrderRepository repository)
{
    private readonly IOrderRepository _repository = repository;

    public virtual async Task<Guid> Action(SaveOrderRequestDto param)
    {
        var order = OrderAdapter.ToDomain(param);

        await _repository.Add(order);

        return order.Id;
    }
}