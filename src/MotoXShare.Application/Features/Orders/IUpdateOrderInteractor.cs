using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Orders;

public interface IUpdateOrderInteractor : IInteractorAsync<bool, UpdateOrderRequestDto>
{
}